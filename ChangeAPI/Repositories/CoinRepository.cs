using ChangeAPI.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI.Repositories
{
    public class CoinRepository : BaseRepository<Coin>
    {
        public CoinRepository(ApplicationContext context) : base(context)
        {

        }

        public List<Coin> GetAllCoins()
        {
            var coins = dbSet.ToList();

            return coins;
        }
    }
}
