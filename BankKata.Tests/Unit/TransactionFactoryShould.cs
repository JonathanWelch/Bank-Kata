using System;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests.Unit
{
    [TestFixture]
    public class TransactionFactoryShould
    {
        [Test]
        public void GetDateOfDeposit()
        {
            var clock = new Mock<IClock>();
            var transactionFactory = new TransactionFactory(clock.Object);

            transactionFactory.CreateDeposit(100.00D, 100.00D);

            clock.Verify(c => c.Today);
        }

        [Test]
        public void CreateDepositTransaction()
        {
            var transactionDate = new DateTime(2017, 2, 21);
            var clock = new Mock<IClock>();
            clock.Setup(c => c.Today).Returns(transactionDate);
            var transactionFactory = new TransactionFactory(clock.Object);

            var expectedDepositTransaction = new Deposit(transactionDate, 100.00D, 150.00);

            var deposit = transactionFactory.CreateDeposit(100.00D, 150.00D);

            Assert.AreEqual(expectedDepositTransaction.ToString(), deposit.ToString());
        }

        [Test]
        public void GetDateOfWithdrawal()
        {
            var clock = new Mock<IClock>();
            var transactionFactory = new TransactionFactory(clock.Object);

            transactionFactory.CreateWithdrawal(100.00D, 100.00D);

            clock.Verify(c => c.Today);
        }

        [Test]
        public void CreateWithdrawalTransaction()
        {
            var transactionDate = new DateTime(2017, 2, 21);
            var clock = new Mock<IClock>();
            clock.Setup(c => c.Today).Returns(transactionDate);
            var transactionFactory = new TransactionFactory(clock.Object);

            var expectedWithdrawal = new Withdrawal(transactionDate, 100.00D, 150.00);

            var withdrawal = transactionFactory.CreateWithdrawal(100.00D, 150.00D);

            Assert.AreEqual(expectedWithdrawal.ToString(), withdrawal.ToString());
        }
    }
}
