using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Models.DataBase
{
    public class TransactionXCoin : ModelDb
    {
        [Required]

        public virtual Transaction Transaction { get; set; }

        public virtual Coin Coin { get; set; }

        public int Quantity { get; set; }
    }
}
