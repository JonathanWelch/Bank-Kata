using System;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests.Unit
{
    [TestFixture]
    public class AccountShould
    {
        private Mock<Transactions> _transactions;
        private Mock<TransactionFactory> _transactionFactory;
        private Account _account;
        private Mock<IPrinter> _printer;

        [SetUp]
        public void SetUp()
        {
            _transactions = new Mock<Transactions>();
            _transactionFactory = new Mock<TransactionFactory>(null);
            _printer = new Mock<IPrinter>();
            _account = new Account(_transactionFactory.Object, _transactions.Object, _printer.Object);
        }

        [Test]
        public void RequestDepositTransaction()
        {
            const double amount = 100.00D;
            _account.Deposit(amount);

            _transactionFactory.Verify(t => t.CreateDeposit(amount, amount));
        }

        [Test]
        public void AddDepositTransaction()
        {
            const double amount = 100.00D;
            const double balance = 100.00D;

            var expectedDeposit = new Deposit(new DateTime(2017, 2, 22), amount, balance);
            _transactionFactory.Setup(t => t.CreateDeposit(amount, balance)).Returns(expectedDeposit);

            _account.Deposit(amount);

            _transactions.Verify(t => t.Add(expectedDeposit));
        }

        [Test]
        public void RequestWithdrawalTransaction()
        {
            const double amount = 100.00D;
            const double balance = -100D;
            _account.Withdraw(amount);

            _transactionFactory.Verify(t => t.CreateWithdrawal(amount, balance));
        }

        [Test]
        public void AddWithdrawalTransaction()
        {
            const double amount = 100.00D;
            const double balance = -100.00D;

            var expectedWithdrawal = new Withdrawal(new DateTime(2017, 2, 22), amount, balance);
            _transactionFactory.Setup(t => t.CreateWithdrawal(amount, balance)).Returns(expectedWithdrawal);

            _account.Withdraw(amount);

            _transactions.Verify(t => t.Add(expectedWithdrawal));
        }

        [Test]
        public void UpdateBalance()
        {
            const double amount = 100.00D;
            const double balanceAfterFirstDeposit = 100.00D;
            const double balanceAfterSecondDeposit = 200.00D;
            const double balanceAfterWithdrawal = 100.00D;

            _account.Deposit(amount);
            _account.Deposit(amount);
            _account.Withdraw(amount);

            _transactionFactory.Verify(t => t.CreateDeposit(amount, balanceAfterFirstDeposit));
            _transactionFactory.Verify(t => t.CreateDeposit(amount, balanceAfterSecondDeposit));
            _transactionFactory.Verify(t => t.CreateWithdrawal(amount, balanceAfterWithdrawal));
        }

        [Test]
        public void RequestTransactionsToPrint()
        {
            _account.Print();
            _transactions.Verify(t => t.ToString());
        }

        [Test]
        public void PrintTransactions()
        {
            const string statement = "21/02/2017 | | 100.00 | 150.00";
            _transactions.Setup(t => t.ToString()).Returns(statement);

            _account.Print();            

            _printer.Verify(p => p.Print(statement));
        }
    }
}
