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
        [HttpGet("{total}/{amountPaid}")]
        public IActionResult Change(double total, double amountPaid)
        {
            return Ok();
        }
    }
}
