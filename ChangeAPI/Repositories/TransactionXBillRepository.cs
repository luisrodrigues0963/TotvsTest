using ChangeAPI.Models.DataBase;
using ChangeAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Repositories
{
    public class TransactionXBillRepository : BaseRepository<TransactionXBill>, ITransactionXBillRepository
    {
        public TransactionXBillRepository(ApplicationContext context) : base(context)
        {
        }

        public void InsertTransactionBill(TransactionXBill transactionXBill)
        {
            dbSet.Add(transactionXBill);
            context.SaveChanges();
        }
    }
}
