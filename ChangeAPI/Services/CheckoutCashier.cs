using ChangeAPI.Models;
using ChangeAPI.Models.DataBase;
using ChangeAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Services
{
    public interface ICheckoutCashier
    {
        ActionResult<IEnumerable<string>> Checkout(double total, double amountPaid);
    }
    public class CheckoutCashier : ICheckoutCashier
    {
        IBillRepository IBillRepository;
        ICoinRepository ICoinRepository;

        public CheckoutCashier(IBillRepository IBillRepository, ICoinRepository ICoinRepository)
        {
            this.IBillRepository = IBillRepository;
            this.ICoinRepository = ICoinRepository;
        }

        public ActionResult<IEnumerable<string>> Checkout(double total, double amountPaid)
        {
            double change = amountPaid - total;


            Payments payments = new Payments(IBillRepository, ICoinRepository);

            Transaction transaction = new Transaction();
            transaction.TotalAmount = total;
            transaction.TotalPaid = amountPaid;
            transaction.Date = DateTime.Now;

            var billResult = payments.ChangeBill(change, transaction);
            var coinResult = payments.ChangeCoin(billResult.Item2, transaction);

            string result = billResult.Item1.ToString() + " " + coinResult;

            return new string[] {"Valor do troco: " + change, "Resultado Esperado: " + result};
        }
    }
}
