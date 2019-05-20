namespace AlphaBank.Server.Entity
{
    public class Account
    {
        public Account(string cardNumber, double balance)
        {
            CardNumber = cardNumber;
            AccountBalance = balance;
        }

        public double AccountBalance { get; set; }
        public string CardNumber { get; }
        public string AccountHolderName { get; set; }
    }
}
