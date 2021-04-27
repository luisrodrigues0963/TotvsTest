using ChangeAPI.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Repositories.Interfaces
{
    public interface ITransactionXCoinRepository
    {
        void InsertTransactionXCoin(TransactionXCoin transactionXCoin);
    }
}
