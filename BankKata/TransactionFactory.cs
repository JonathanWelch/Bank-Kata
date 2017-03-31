namespace BankKata
{
    public class TransactionFactory
    {
        private readonly IClock _clock;

        public TransactionFactory(IClock clock)
        {
            _clock = clock;
        }

        public virtual Deposit CreateDeposit(double amount, double balance)
        {
            return new Deposit(_clock.Today, amount, balance);
        }

        public virtual Withdrawal CreateWithdrawal(double amount, double balance)
        {
            return new Withdrawal(_clock.Today, amount, balance);
        }
    }
}