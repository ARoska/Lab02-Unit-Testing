using System;

namespace UnitTesting
{
    public class Program
    {
        public static void Main(string[] args)
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
                    balance = Convert.ToDecimal(withdrawMoney(balance, value));

                    Console.Clear();
                    displayBalance(balance);
                    Console.WriteLine("Please make another selection:");
                    userSelection = selectionPrompt();
                }

                else if (userSelection.ToUpper() == "3" || userSelection.ToUpper() == "ADD MONEY" || userSelection.ToUpper() == "ADD" || userSelection.ToUpper() == "DEPOSIT")
                {
                    decimal value = 0;
                    balance = Convert.ToDecimal(addMoney(balance, value));
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

        /// <summary>
        /// This method will display a menu with the four options that the user has for interacting with the app.  
        /// It will return the user's input to Main so that the app can follow up. 
        /// </summary>
        /// <returns></returns>
        public static string selectionPrompt()
        {
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Add Money");
            Console.WriteLine("4. Exit");
            Console.Write("Please make a selection: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// This simple method will convert the balance parameter into a string and display it on the console.
        /// </summary>
        /// <param name="balance">User's current balance</param>
        public static void displayBalance(decimal balance)
        {
            Console.WriteLine($"Your available balance is: {balance.ToString("C")}");
            Console.WriteLine();
        }

        /// <summary>
        /// This will take the user's current balance and add subtract the amount of their withdrawal, returning their new balance.
        /// </summary>
        /// <param name="balance">User's current balance</param>
        /// <param name="value">Amount of money the user wishes to withdraw</param>
        /// <returns>New balance after withdraw is removed</returns>
        public static string withdrawMoney(decimal balance, decimal value)
        {


            decimal newBalance = (balance - value);

            if(newBalance >= 0)
            {
                return newBalance.ToString();
            }

            else
            {
                return "Cannot withdraw.  Your balance cannot be negative.";
            }
        }

        /// <summary>
        /// This will take the user's current balance and add the amount of their deposit, returning their new balance.
        /// </summary>
        /// <param name="balance">User's current balance</param>
        /// <param name="value">Amount of money the user wishers to deposit</param>
        /// <returns>New balance after deposit is added</returns>
        public static decimal addMoney(decimal balance, decimal value)
        {
            return (balance + value);
        }
    }
}
