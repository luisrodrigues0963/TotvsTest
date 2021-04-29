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
        private readonly IBillRepository IBillRepository;
        private readonly ICoinRepository ICoinRepository;
        private readonly ITransactionXBillRepository ITransactionXBillRepository;
        private readonly ITransactionXCoinRepository ITransactionXCoinRepository;
        private readonly ITransactionRepository ITransactionRepository;
        public CheckoutCashier(IBillRepository IBillRepository, ICoinRepository ICoinRepository,
            ITransactionXBillRepository ITransactionXBillRepository, ITransactionXCoinRepository ITransactionXCoinRepository, ITransactionRepository ITransactionRepository)
        {
            this.IBillRepository = IBillRepository;
            this.ICoinRepository = ICoinRepository;
            this.ITransactionXBillRepository = ITransactionXBillRepository;
            this.ITransactionXCoinRepository = ITransactionXCoinRepository;
            this.ITransactionRepository = ITransactionRepository;
        }

        public ActionResult<IEnumerable<string>> Checkout(double total, double amountPaid)
        {
            double change = amountPaid - total;

            Payments payments = new Payments(IBillRepository, ICoinRepository, ITransactionXBillRepository, ITransactionXCoinRepository);

            Transaction transaction = new Transaction();
            transaction.TotalAmount = total;
            transaction.TotalPaid = amountPaid;
            transaction.Date = DateTime.Now;

            ITransactionRepository.InsertTransaction(transaction);

            var billResult = payments.ChangeBill(change, transaction);
            var coinResult = payments.ChangeCoin(billResult.Item2, transaction);

            string result = billResult.Item1.ToString() + " " + coinResult;

            return new string[] { "Valor do troco: " + change, "Resultado Esperado: " + result };

        }
    }
}
