using System;
using NUnit.Framework;

namespace BankKata.Tests.Unit
{
    [TestFixture]
    public class WithdrawalShould
    {
        [Test]
        public void ToStringItSelf()
        {
            var withdrawal = new Withdrawal(new DateTime(2017, 2, 21), 100.00D, 150.00D);
            var stringRepresentation = withdrawal.ToString();

            Assert.That(stringRepresentation, Is.EqualTo("21/02/2017 | | 100.00 | 150.00"));
        }
    }
}
