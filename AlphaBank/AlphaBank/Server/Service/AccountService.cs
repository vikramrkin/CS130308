using System;
using AlphaBank.Server.Entity;

namespace AlphaBank.Server.Service
{
    public class AccountService : IAccountService
    {
        private readonly Account _account;
        private readonly object _lockObject = new object();

        public AccountService(Account account)
        {
            _account = account;
        }

        public double GetCurrentBalance()
        {
            return _account.AccountBalance;
        }

        public void Topup(double amount)
        {
            if (amount <= 0.0)
            {
                throw new ArgumentException($"Topups should be a value greater than 0. Received value is '{amount}'");
            }

            UpdateBalance(amount);
        }

        public bool Withdraw(double amount)
        {
            if (amount <= 0.0)
            {
                throw new ArgumentException($"Withdrawals should be a value greater than 0. Received value is '{amount}'");
            }

            if (_account.AccountBalance >= amount)
            {
                UpdateBalance(amount * -1.0);
            }
            else
            {
                return false;
            }

            return true;
        }

        private void UpdateBalance(double amount)
        {
            lock (_lockObject)
            {
                _account.AccountBalance += amount;
            }
        }
    }

    public interface IAccountService
    {
        double GetCurrentBalance();
        void Topup(double amount);
        bool Withdraw(double d);
    }
}
