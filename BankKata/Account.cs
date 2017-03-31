namespace BankKata
{
    public class Account
    {
        private readonly TransactionFactory _transactionFactory;
        private readonly Transactions _transactions;
        private readonly IPrinter _printer;
        private double _balance;

        public Account(TransactionFactory transactionFactory, Transactions transactions, IPrinter printer)
        {
            _transactionFactory = transactionFactory;
            _transactions = transactions;
            _printer = printer;
        }

        public void Deposit(double amount)
        {
            _balance += amount;
            var deposit = _transactionFactory.CreateDeposit(amount, _balance);
            _transactions.Add(deposit);
        }

        public void Withdraw(double amount)
        {
            _balance -= amount;
            var withdrawal = _transactionFactory.CreateWithdrawal(amount, _balance);
            _transactions.Add(withdrawal);
        }

        public void Print()
        {
            var transactions = _transactions.ToString();
            _printer.Print(transactions);
        }
    }
}