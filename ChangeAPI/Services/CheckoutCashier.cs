using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Services
{
    public interface ICheckoutCashier
    {
        ActionResult<IEnumerable<string>> Checkout(double total, double totalPaid);
    }
    public class CheckoutCashier : ICheckoutCashier
    {
        public ActionResult<IEnumerable<string>> Checkout(double total, double totalPaid)
        {
            return new string[] {"Troco"};
        }
    }
}
