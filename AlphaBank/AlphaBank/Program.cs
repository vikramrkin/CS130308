using System;
using AlphaBank.Client;
using AlphaBank.Server.Entity;
using AlphaBank.Server.Service;

namespace AlphaBank
{
    class Program
    {
        private static Card _card;
        private static IAccountService _accountService;


        static void Main(string[] args)
        {
            _card = new Card(123456789, "John Dow", DateTime.Today.AddYears(2), 1212);
            _accountService = new AccountService(new Account(_card.Number, 250.0));

            Console.Write($"Hi {_card.Name}, welcome to Alpha Bank.\nPlease enter your pin to continue: ");
            var strPin = Console.ReadLine();

            if (IsValidPin(strPin))
            {
                Console.WriteLine("Pin correct.");

                while (true)
                {
                    PrintMenu();

                    var input = Console.ReadLine();

                    if (input != null && input.ToUpper().Equals("Q"))
                    {
                        break;
                    }

                    PerformAction(input);
                }
            }
            else
            {
                Console.WriteLine("Sorry, this is invalid pin. Please try again.");
            }
        }

        private static bool IsValidPin(string strPin)
        {
            if (int.TryParse(strPin, out var pin))
            {
                return _card.IsValidPin(pin);
            }

            Console.WriteLine("Please enter a numeric value for the pin.");
            return false;
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\nPlease choose from one of the options below (press q to quit):");
            Console.WriteLine("1 - to view your balance");
            Console.WriteLine("2 - to top up");
            Console.WriteLine("3 - to withdraw");
            Console.Write("Please enter your selection: ");
        }

        private static void PerformAction(string input)
        {
            try
            {
                switch (input)
                {
                    case "1":
                        var currentBalance = _accountService.GetCurrentBalance();
                        Console.WriteLine($"Current balance is - {currentBalance}");
                        break;

                    case "2":
                        Console.Write("Enter the amout of topup: ");
                        var topupAmount = AcceptNumericInput();

                        if (topupAmount.HasValue)
                        {
                            _accountService.Topup(topupAmount.Value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount entered.");
                        }

                        Console.WriteLine($"Topup successful. New balance is {_accountService.GetCurrentBalance()}");
                        break;
                    case "3":
                        Console.Write("Enter the amount to withdraw: ");
                        var withdrawalAmount = AcceptNumericInput();

                        if (withdrawalAmount.HasValue)
                        {
                            Console.WriteLine(_accountService.Withdraw(withdrawalAmount.Value)
                                ? $"Withdraw successful. New balance is {_accountService.GetCurrentBalance()}"
                                : "Insufficient balance");
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount entered.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static double? AcceptNumericInput()
        {
            var strAmount = Console.ReadLine();
            if (double.TryParse(strAmount, out var amount))
            {
                return amount;
            }

            return null;
        }
    }
}
