using ChangeAPI.Models.DataBase;
using ChangeAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Repositories
{
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        public BillRepository(ApplicationContext context) : base(context)
        {

        }

        public List<Bill> GetAllBills()
        {
            var bills = dbSet.ToList();

            return bills;
        }
    }
}
