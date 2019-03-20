using System;

namespace UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            bool execute = true;
            string userSelection;

            Console.WriteLine("Welcome to Bank of CF!");
            Console.WriteLine();
            Console.WriteLine("Please make a selection from the following commands:");
            userSelection = selectionPrompt();

            do
            {

                if(userSelection.ToUpper() == "1" || userSelection.ToUpper() == "VIEW BALANCE" || userSelection.ToUpper() == "VIEW" || userSelection.ToUpper() == "BALANCE")
                {
                    viewBalance();
                    Console.WriteLine();
                    Console.WriteLine("Please make another selection:");
                    userSelection = selectionPrompt();
                }

                else if (userSelection.ToUpper() == "2" || userSelection.ToUpper() == "WITHDRAW MONEY" || userSelection.ToUpper() == "WITHDRAW" || userSelection.ToUpper() == "WITHDRAWAL")
                {
                    withdrawMoney();
                    Console.WriteLine();
                    Console.WriteLine("Please make another selection:");
                    userSelection = selectionPrompt();
                }

                else if (userSelection.ToUpper() == "3" || userSelection.ToUpper() == "ADD MONEY" || userSelection.ToUpper() == "ADD" || userSelection.ToUpper() == "DEPOSIT")
                {
                    addMoney();
                    Console.WriteLine();
                    Console.WriteLine("Please make another selection:");
                    userSelection = selectionPrompt();
                }

                else if (userSelection.ToUpper() == "1" || userSelection.ToUpper() == "VIEW BALANCE" || userSelection.ToUpper() == "VIEW" || userSelection.ToUpper() == "BALANCE")
                {
                    execute = false;
                }

                else
                {
                    Console.WriteLine("Please make a valid selection.");
                    Console.WriteLine();
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
            Console.Write("Input selection: ");
            return Console.ReadLine();
        }

        static int viewBalance()
        {

        }

        static int withdrawMoney()
        {

        }

        static int addMoney()
        {

        }
    }
}
