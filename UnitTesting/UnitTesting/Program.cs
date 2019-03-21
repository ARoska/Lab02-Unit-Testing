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
            string newBalance;

            Console.WriteLine("Welcome to Bank of CF!");
            Console.WriteLine();
            userSelection = displayBalance(balance);

            do
            {

                if (userSelection.ToUpper() == "1" || userSelection.ToUpper() == "VIEW BALANCE" || userSelection.ToUpper() == "VIEW" || userSelection.ToUpper() == "BALANCE")
                {
                    Console.Clear();
                    userSelection = displayBalance(balance);
                }

                else if (userSelection.ToUpper() == "2" || userSelection.ToUpper() == "WITHDRAW MONEY" || userSelection.ToUpper() == "WITHDRAW" || userSelection.ToUpper() == "WITHDRAWAL")
                {
                    try
                    {
                        Console.WriteLine("How much would you like to withdraw?");
                        string withdrawalInput = Console.ReadLine();

                        newBalance = withdrawMoney(balance, withdrawalInput);

                        balance = Convert.ToDecimal(newBalance);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Something went wrong: {e}");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    finally
                    {
                        Console.Clear();
                        displayBalance(balance);
                    }
                }

                else if (userSelection.ToUpper() == "3" || userSelection.ToUpper() == "ADD MONEY" || userSelection.ToUpper() == "ADD" || userSelection.ToUpper() == "DEPOSIT")
                {
                    decimal value = 0;
                    balance = Convert.ToDecimal(addMoney(balance, value));
                    Console.Clear();
                    displayBalance(balance);
                }

                else if (userSelection.ToUpper() == "4" || userSelection.ToUpper() == "EXIT" || userSelection.ToUpper() == "QUIT" || userSelection.ToUpper() == "CLOSE" || userSelection.ToUpper() == "END")
                {
                    execute = false;
                }

                else
                {
                    Console.WriteLine("Please make a valid selection.  Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    displayBalance(balance);
                }

            } while (execute == true);
        }


        /// <summary>
        /// This method will display the user's current balance at the top of the screen,
        /// followed by a menu with the four options that the user has for interacting with the app.
        /// It will return the user's input to Main so that the app can follow up.
        /// </summary>
        /// <param name="balance">User's current balance.</param>
        /// <returns>User's task selection.</returns>
        public static string displayBalance(decimal balance)
        {
            Console.WriteLine($"Your available balance is: {balance.ToString("C")}");
            Console.WriteLine();
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Add Money");
            Console.WriteLine("4. Exit");
            Console.Write("Please make a selection: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// This will take the user's current balance as a string, convert it to a decimal,
        /// and add subtract the amount of their withdrawal, returning their new balance.
        /// The user cannot make negative withdrawals or put their balance into the negative.
        /// </summary>
        /// <param name="balance">User's current balance</param>
        /// <param name="value">Amount of money the user wishes to withdraw.  Cannot be negative.  Cannot be more than balance.</param>
        /// <returns>New balance after withdraw is removed, or error message if operation fails.</returns>
        public static string withdrawMoney(decimal balance, string value)
        {
            string newBalance;
            try
            {
                decimal withdrawalValue = Convert.ToDecimal(value);

                if (withdrawalValue < 0)
                {
                    newBalance = "Cannot withdraw a negative amount.";
                }
                else if ((balance - withdrawalValue) < 0)
                {
                    newBalance = "Cannot withdraw.  Your balance cannot be negative.";
                }
                else
                {
                    newBalance = Convert.ToString(balance - withdrawalValue);
                }
                return newBalance.ToString();
            }
            catch (FormatException)
            {
                throw new System.ArgumentException("Withdrawal amount must be a positive number.");
            }

        }

        /// <summary>
        /// This will take the user's current balance and add the amount of their deposit, returning their new balance.  Cannot add negative deposits.
        /// </summary>
        /// <param name="balance">User's current balance.</param>
        /// <param name="value">Amount of money the user wishers to deposit.  Cannot be negative.</param>
        /// <returns>New balance after deposit is added.</returns>
        public static string addMoney(decimal balance, decimal value)
        {
            if (value < 0)
            {
                return "Cannot deposit a negative amount.";
            }

            decimal newBalance = (balance + value);

            return newBalance.ToString();
        }
    }
}
