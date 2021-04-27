using ChangeAPI.Models.DataBase;
using ChangeAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Repositories
{
    public class TransactionXCoinRepository : BaseRepository<TransactionXCoin>, ITransactionXCoinRepository
    {
        public TransactionXCoinRepository(ApplicationContext context) : base(context)
        {
        }

        public void InsertTransactionXCoin(TransactionXCoin transactionXCoin)
        {
            dbSet.Add(transactionXCoin);
            context.SaveChanges();
        }
    }
}
