using ChangeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeController : ControllerBase
    {
        private readonly ICheckoutCashier checkoutCashier;
        public ChangeController(ICheckoutCashier checkoutCashier)
        {
            this.checkoutCashier = checkoutCashier;
        }

        [HttpGet("{total}/{amountPaid}")]
        public ActionResult<IEnumerable<string>> Change(double total, double amountPaid)
        {
            return checkoutCashier.Checkout(total,amountPaid);
        }
    }
}
