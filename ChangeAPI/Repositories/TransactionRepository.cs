using ChangeAPI.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationContext context) : base(context)
        {

        }

        public Transaction InsertTransaction (Transaction transaction)
        {
            dbSet.Add(transaction);
            context.SaveChanges();

            return transaction;
        }
    }
}
