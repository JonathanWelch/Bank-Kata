using System.Collections.Generic;

namespace BankKata
{
    public class Transactions
    {
        private readonly Stack<ITransaction> _transactions = new Stack<ITransaction>();

        public virtual void Add(ITransaction transaction)
        {
            _transactions.Push(transaction);
        }

        public override string ToString()
        {
            return string.Join(System.Environment.NewLine, _transactions);
        }
    }
}