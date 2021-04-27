using ChangeAPI.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeAPI
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bill>().HasKey(t => t.Id);

            modelBuilder.Entity<Coin>().HasKey(t => t.Id);

            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);

            modelBuilder.Entity<TransactionXCoin>().HasKey(t => t.Id);

            modelBuilder.Entity<TransactionXBill>().HasKey(t => t.Id);
        }
    }
}
