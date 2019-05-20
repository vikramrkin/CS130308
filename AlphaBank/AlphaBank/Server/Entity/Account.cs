namespace AlphaBank.Server.Entity
{
    public class Account
    {
        public Account(long cardNumber, double balance)
        {
            CardNumber = cardNumber;
            AccountBalance = balance;
        }

        public double AccountBalance { get; set; }
        public long CardNumber { get; }
        public string AccountHolderName { get; set; }
    }
}
