using System;

namespace BankKata
{
    public class Deposit : ITransaction
    {
        private readonly DateTime _transactionDate;
        private readonly double _amount;
        private readonly double _balance;

        public Deposit(DateTime transactionDate, double amount, double balance)
        {
            _transactionDate = transactionDate;
            _amount = amount;
            _balance = balance;
        }

        public override string ToString()
        {
            return $"{_transactionDate:d} | {_amount:F} | | {_balance:F}";
        }
    }
}