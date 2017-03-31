using System;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests.Outside
{
    [TestFixture]
    public class BankShould
    {
        [Test]
        public void PrintStatementOfTransactions()
        {
            var clock = new Mock<IClock>();
            var printer = new Mock<IPrinter>();
            var account = new Account(new TransactionFactory(clock.Object), new Transactions(), printer.Object);

            clock.Setup(c => c.Today).Returns(new DateTime(2017, 2, 19));
            account.Deposit(100.00D);
            clock.Setup(c => c.Today).Returns(new DateTime(2017, 2, 20));
            account.Deposit(150.00D);
            clock.Setup(c => c.Today).Returns(new DateTime(2017, 2, 21));
            account.Withdraw(100.00D);

            account.Print();

            const string expectedStatement = @"21/02/2017 | | 100.00 | 150.00
20/02/2017 | 150.00 | | 250.00
19/02/2017 | 100.00 | | 100.00";

            printer.Verify(p => p.Print(expectedStatement));
        }
    }
}
