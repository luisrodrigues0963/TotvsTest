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
        public IActionResult Change(double total, double amountPaid)
        {

            if (total > amountPaid)
            {
                return BadRequest("O total não pode ser maior que o valor pago");
            }
            else if (total <= 0 || amountPaid <= 0)
            {
                return BadRequest("Não podem existir valores 0 ou negativos");
            }
            else
            {
                return Ok(checkoutCashier.Checkout(total, amountPaid));
            }

           
        }
    }
}
