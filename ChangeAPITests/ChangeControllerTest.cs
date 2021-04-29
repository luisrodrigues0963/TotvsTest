using ChangeAPI.Controllers;
using ChangeAPI.Models;
using ChangeAPI.Models.DataBase;
using ChangeAPI.Repositories.Interfaces;
using ChangeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChangeAPITests
{
    public class ChangeControllerTest
    {
        [Fact]
        public void ChangeWithCorrectValues()
        {
            //Arrange

            Mock<IBillRepository> mockBill = new Mock<IBillRepository>();
            Mock<ICoinRepository> mockCoin = new Mock<ICoinRepository>();
            Mock<ITransactionRepository> mockTransaction = new Mock<ITransactionRepository>();
            Mock<ITransactionXBillRepository> mockTransactionBill = new Mock<ITransactionXBillRepository>();
            Mock<ITransactionXCoinRepository> mockTransactionCoin = new Mock<ITransactionXCoinRepository>();


            CheckoutCashier checkoutCashier = new CheckoutCashier(mockBill.Object, mockCoin.Object, 
                    mockTransactionBill.Object, mockTransactionCoin.Object, mockTransaction.Object);
            
            ChangeController changeController = new ChangeController(checkoutCashier);

            Payments payments = new Payments(mockBill.Object, mockCoin.Object, mockTransactionBill.Object, mockTransactionCoin.Object);

            Transaction transaction = new Transaction();
            transaction.Date = DateTime.Now;
            transaction.TotalAmount = 20;
            transaction.TotalPaid = 30;

            List<Bill> bills = new List<Bill>();
            List<Coin> coins = new List<Coin>();

            mockBill.Setup(t => t.GetAllBills()).Returns(bills);
            mockCoin.Setup(t => t.GetAllCoins()).Returns(coins);
            checkoutCashier.Checkout(20, 30);

            payments.ChangeBill(10, transaction);
            payments.ChangeCoin(0, transaction);

            //Act

            var response = changeController.Change(20, 30);

            //Assert

            Assert.IsType<OkObjectResult>(response);

        }

        [Fact]
        public void ChangeWithTotalSmallerThanAmountPaid()
        {
            //Arrange

            Mock<IBillRepository> mockBill = new Mock<IBillRepository>();
            Mock<ICoinRepository> mockCoin = new Mock<ICoinRepository>();
            Mock<ITransactionRepository> mockTransaction = new Mock<ITransactionRepository>();
            Mock<ITransactionXBillRepository> mockTransactionBill = new Mock<ITransactionXBillRepository>();
            Mock<ITransactionXCoinRepository> mockTransactionCoin = new Mock<ITransactionXCoinRepository>();


            CheckoutCashier checkoutCashier = new CheckoutCashier(mockBill.Object, mockCoin.Object,
                    mockTransactionBill.Object, mockTransactionCoin.Object, mockTransaction.Object);

            ChangeController changeController = new ChangeController(checkoutCashier);

            //Act

            var response = changeController.Change(50, 40);

            //Assert
            Assert.IsType<BadRequestObjectResult>(response);

        }

        [Fact]
        public void ChangeWithZeroValues()
        {
            //Arrange

            Mock<IBillRepository> mockBill = new Mock<IBillRepository>();
            Mock<ICoinRepository> mockCoin = new Mock<ICoinRepository>();
            Mock<ITransactionRepository> mockTransaction = new Mock<ITransactionRepository>();
            Mock<ITransactionXBillRepository> mockTransactionBill = new Mock<ITransactionXBillRepository>();
            Mock<ITransactionXCoinRepository> mockTransactionCoin = new Mock<ITransactionXCoinRepository>();


            CheckoutCashier checkoutCashier = new CheckoutCashier(mockBill.Object, mockCoin.Object,
                    mockTransactionBill.Object, mockTransactionCoin.Object, mockTransaction.Object);

            ChangeController changeController = new ChangeController(checkoutCashier);

            //Act

            var response = changeController.Change(0,0);

            //Assert
            Assert.IsType<BadRequestObjectResult>(response);

        }
    }

   

    
}
