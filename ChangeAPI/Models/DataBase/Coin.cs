using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Models.DataBase
{
    public class Coin : ModelDb
    {
        [Required]

        public string Description { get; set; }

        public int Value { get; set; }
    }
}
