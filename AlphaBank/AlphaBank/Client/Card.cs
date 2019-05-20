using System;

namespace AlphaBank.Client
{
    public class Card
    {
        public Card(long number, string name, DateTime expiryDate, int pin)
        {
            Number = number;
            Name = name;
            ExpiryDate = expiryDate;
            Pin = pin;
        }

        public long Number { get; private set; }
        public string Name { get; private set; }
        public DateTime ExpiryDate { get; set; }

        private int _pin;
        public int Pin
        {
            set => _pin = value;
        }


        public bool IsValidPin(int pin)
        {
            return pin == _pin;
        }
    }
}
