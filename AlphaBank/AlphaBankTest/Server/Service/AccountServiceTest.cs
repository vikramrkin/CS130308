using System;
using AlphaBank.Server.Entity;
using AlphaBank.Server.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlphaBankTest.Server.Service
{
    [TestClass]
    public class AccountServiceTest
    {
        private const string TestCardNumber = "123456789999";
        private IAccountService _accountService;

        [TestInitialize]
        public void Initialise()
        {
            var account = new Account(TestCardNumber, 100);
            _accountService = new AccountService(account);
        }

        
        [TestMethod]
        public void TopupIncreasesTheBalance()
        {
            //Arrange
            _accountService.Topup(225.0);


            //Act
            var balance = _accountService.GetCurrentBalance();

            //Assert
            Assert.AreEqual(325.0, balance);
        }

        [TestMethod]
        public void WithdrawalDecreasesTheBalance()
        {
            //Arrange
            _accountService.Withdraw(25.0);

            //Act
            var balance = _accountService.GetCurrentBalance();

            //Assert
            Assert.AreEqual(75.0, balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroTopupResultsInException()
        {
            //Arrange

            //Act
            _accountService.Topup(0.0);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeTopupResultsInException()
        {
            //Arrange

            //Act
            _accountService.Topup(-20.5);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroWithdrawalResultsInException()
        {
            //Arrange

            //Act
            _accountService.Withdraw(0.0);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeWithdrawalResultsInException()
        {
            //Arrange

            //Act
            _accountService.Withdraw(-9.22);

            //Assert
        }

        [TestMethod]
        public void WithdrawMoreThanTheBalanceIsHandled()
        {
            //Arrange

            //Act
            var result = _accountService.Withdraw(5000);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WithdrawAllTheBalanceIsAllowed()
        {
            //Arrange

            //Act
            var result = _accountService.Withdraw(100);

            //Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, _accountService.GetCurrentBalance());
        }

    }
}
