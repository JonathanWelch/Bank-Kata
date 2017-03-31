using System;
using NUnit.Framework;

namespace BankKata.Tests.Unit
{
    [TestFixture]
    public class DepositShould
    {
        [Test]
        public void ToStringItSelf()
        {
            var depositTransaction = new Deposit(new DateTime(2017,2,21), 100.00D, 150.00D);
            var stringRepresentation = depositTransaction.ToString();

            Assert.That(stringRepresentation, Is.EqualTo("21/02/2017 | 100.00 | | 150.00"));
        }
    }
}
