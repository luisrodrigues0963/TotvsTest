using ChangeAPI.Models.DataBase;
using ChangeAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeAPI.Models
{
    public class Payments
    {
        private readonly IBillRepository IBillRepository;
        private readonly ICoinRepository ICoinRepository;
        private readonly ITransactionXBillRepository ITransactionXBillRepository;
        private readonly ITransactionXCoinRepository ITransactionXCoinRepository;

        public Payments(IBillRepository IBillRepository, ICoinRepository ICoinRepository, 
            ITransactionXBillRepository ITransactionXBillRepository, ITransactionXCoinRepository ITransactionXCoinRepository)
        {
            this.IBillRepository = IBillRepository;
            this.ICoinRepository = ICoinRepository;
            this.ITransactionXBillRepository = ITransactionXBillRepository;
            this.ITransactionXCoinRepository = ITransactionXCoinRepository;
        }

        public (StringBuilder, double) ChangeBill(double change, Transaction transaction)
        {
            StringBuilder billsString = new StringBuilder();

            List<Bill> bill = IBillRepository.GetAllBills();

            foreach(var bills in bill)
            {
                double calculation = Math.Floor(change / bills.Value);
                change = Math.Round(change, 2);


                if (change == 0)
                {
                    break;
                }

                if(change/bills.Value>=1)
                {
                    TransactionXBill transactionXBill = new TransactionXBill();

                    billsString.Append(" Nota de " + bills.Value + " " + "= " + calculation);
                    change -= bills.Value * calculation;
                    transactionXBill.Bill = bills;
                    transactionXBill.Transaction = transaction;
                    transactionXBill.Quantity = Convert.ToInt32(calculation);

                    ITransactionXBillRepository.InsertTransactionBill(transactionXBill);
                }
            }

            return (billsString, change);

        }

        public StringBuilder ChangeCoin(double change, Transaction transaction)
        {
            StringBuilder coinsString = new StringBuilder();

            List<Coin> coins = ICoinRepository.GetAllCoins();

            foreach(var coin in coins)
            {
                double calculation = Math.Floor(change / coin.Value);

                if(change==0)
                {
                    break;
                }

                if(change/coin.Value>=1)
                {
                    TransactionXCoin transactionXCoin = new TransactionXCoin();
                    coinsString.Append(" Moeda de " + coin.Value + " " + "= " + calculation);
                    change -= coin.Value * calculation;
                    change = Math.Round(change, 2);

                    transactionXCoin.Coin = coin;
                    transactionXCoin.Transaction = transaction;
                    transactionXCoin.Quantity = Convert.ToInt32(calculation);

                    ITransactionXCoinRepository.InsertTransactionXCoin(transactionXCoin);
                }
            }

            return coinsString;
        }

    }
}
