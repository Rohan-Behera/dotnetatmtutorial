using System.Collections;

namespace ATM
{
    public class AtmWorking
    {

        private const string CARD_NUMBER = "1234567890123456";
        private const int PIN = 1234;
        private const decimal BALANCE = 15000;

        private static decimal WithdrawalLimit = 1000;
        private static int MaxTransactionsPerDay = 10;
        private static int TransactionsCount = 0;
        private static decimal Balance = BALANCE;

        private ArrayList withdraw = new ArrayList();


        public void checkBalance()
        {
            Console.WriteLine($"Your balance is ${Balance}");

        }

        public void withdrawal()
        {
            Console.Write("Enter amount to withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            withdraw.Add(amount);

            if (amount > WithdrawalLimit)
            {
                Console.WriteLine($"Withdrawal limit exceeded. Maximum withdrawal is ${WithdrawalLimit}.");
            }
            else if (TransactionsCount >= MaxTransactionsPerDay)
            {
                Console.WriteLine($"Transaction limit exceeded. Maximum transactions per day is {MaxTransactionsPerDay}.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                Balance -= amount;
                TransactionsCount++;
                Console.WriteLine($"Dispensing ${amount}...");
                Console.WriteLine($"Your new balance is ${Balance}");
            }

        }

        public void recentTransaction()
        {
            if (withdraw.Count == 0)
            {
                Console.WriteLine("There are no Transactions yet!");
            }
            else
            {

                int index = 1;
                foreach (decimal withdrawals in withdraw)
                {
                    Console.WriteLine(index + ". transaction is of amount = " + withdrawals);
                    index++;
                }
            }

        }

        public void AtmValidation()
        {
            

            Console.Write("Please enter your card number: ");
            string cardNumber = Console.ReadLine();

            if (cardNumber != CARD_NUMBER)
            {
                Console.WriteLine("Card not recognized. Please try again later.");
                return;
            }

            Console.Write("Please enter your PIN: ");
            int pin = int.Parse(Console.ReadLine());

            if (pin != PIN)
            {
                Console.WriteLine("Invalid PIN. Please try again later.");
                return;
            }
        }
    }
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ATM!");

            AtmWorking Atm = new AtmWorking();

           
            Atm.AtmValidation();

            Console.WriteLine("Welcome!");

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Check balance");
                Console.WriteLine("2. Withdraw cash");
                Console.WriteLine("3. View recent transactions");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Atm.checkBalance();
                        break;
                    case 2:
                        Atm.withdrawal();
                        break;

                    case 3:
                        Atm.recentTransaction();
                        /* Console.WriteLine("To be Implemented");*/
                        break;

                    case 4:
                        Console.WriteLine("Have a nice day!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }

        }
    }
}
