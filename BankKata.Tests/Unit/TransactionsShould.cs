using System;
using NUnit.Framework;

namespace BankKata.Tests.Unit
{
    [TestFixture]
    public class TransactionsShould
    {
        private Transactions _transactions;

        [SetUp]
        public void SetUp()
        {
            _transactions = new Transactions();
        }

        [Test]
        public void AddDepositTransaction()
        {
            var transactionDate = new DateTime(2017, 2, 21);
            const double amount = 100.00D;
            const double balance = 150.00D;
            var deposit = new Deposit(transactionDate, amount, balance);
            const string expectedTransaction = "21/02/2017 | 100.00 | | 150.00";

            _transactions.Add(deposit);

            Assert.AreEqual(expectedTransaction, _transactions.ToString());
        }

        [Test]
        public void AddWithdrawalTransaction()
        {
            var transactionDate = new DateTime(2017, 2, 21);
            const double amount = 100.00D;
            const double balance = 150.00D;

            var withdrawal = new Withdrawal(transactionDate, amount, balance);
            const string expectedTransaction = "21/02/2017 | | 100.00 | 150.00";

            _transactions.Add(withdrawal);

            Assert.AreEqual(expectedTransaction, _transactions.ToString());
        }

        [Test]
        public void AddDepositAndWithdrawal()
        {
            var transactionDate = new DateTime(2017, 2, 21);
            const double amount = 100.00D;
            const double balanceAfterDeposit = 100.00D;
            const double balanceAfterWithdrawal = 0.00D;

            var deposit = new Deposit(transactionDate, amount, balanceAfterDeposit);
            var withdrawal = new Withdrawal(transactionDate, amount, balanceAfterWithdrawal);

            _transactions.Add(deposit);
            _transactions.Add(withdrawal);

            const string expectedTransactiosn = @"21/02/2017 | | 100.00 | 0.00
21/02/2017 | 100.00 | | 100.00";
            Assert.AreEqual(expectedTransactiosn, _transactions.ToString());
        }
    }
}
