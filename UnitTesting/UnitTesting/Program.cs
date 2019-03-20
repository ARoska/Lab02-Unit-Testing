using System;

namespace UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            bool execute = true;
            string userSelection;
            decimal balance = 2000.32659M;

            Console.WriteLine("Welcome to Bank of CF!");
            Console.WriteLine();
            displayBalance(balance);
            Console.WriteLine();
            Console.WriteLine("Please make a selection from the following commands:");
            userSelection = selectionPrompt();

            do
            {

                if(userSelection.ToUpper() == "1" || userSelection.ToUpper() == "VIEW BALANCE" || userSelection.ToUpper() == "VIEW" || userSelection.ToUpper() == "BALANCE")
                {
                    Console.Clear();
                    displayBalance(balance);
                    Console.WriteLine("Please make another selection:");
                    userSelection = selectionPrompt();
                }

                else if (userSelection.ToUpper() == "2" || userSelection.ToUpper() == "WITHDRAW MONEY" || userSelection.ToUpper() == "WITHDRAW" || userSelection.ToUpper() == "WITHDRAWAL")
                {
                    decimal value = 0;
                    balance = withdrawMoney(balance, value);
                    Console.Clear();
                    displayBalance(balance);
                    Console.WriteLine("Please make another selection:");
                    userSelection = selectionPrompt();
                }

                else if (userSelection.ToUpper() == "3" || userSelection.ToUpper() == "ADD MONEY" || userSelection.ToUpper() == "ADD" || userSelection.ToUpper() == "DEPOSIT")
                {
                    decimal value = 0;
                    balance = addMoney(balance, value);
                    Console.Clear();
                    displayBalance(balance);
                    Console.WriteLine("Please make another selection:");
                    userSelection = selectionPrompt();
                }

                else if (userSelection.ToUpper() == "4" || userSelection.ToUpper() == "EXIT" || userSelection.ToUpper() == "QUIT" || userSelection.ToUpper() == "CLOSE" || userSelection.ToUpper() == "END")
                {
                    execute = false;
                }

                else
                {
                    Console.WriteLine("Please make a valid selection.");
                    Console.WriteLine();
                    displayBalance(balance);
                    userSelection = selectionPrompt();
                }

            } while (execute == true);


        }

        static string selectionPrompt()
        {
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Add Money");
            Console.WriteLine("4. Exit");
            Console.Write("Please make a selection: ");
            return Console.ReadLine();
        }

        static void displayBalance(decimal balance)
        {
            Console.WriteLine($"Your available balance is: {balance.ToString("C")}");
            Console.WriteLine();
        }

        static decimal withdrawMoney(decimal balance, decimal value)
        {
            return (balance - value);
        }

        static decimal addMoney(decimal balance, decimal value)
        {
            return (balance + value);
        }
    }
}
