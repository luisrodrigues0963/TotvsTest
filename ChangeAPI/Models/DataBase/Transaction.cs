using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Models.DataBase
{
    public class Transaction: ModelDb
    {
        [Required]

        public double TotalAmount { get; set; }

        public double TotalPaid { get; set; }

        public DateTime Date { get; set; }
    }
}
