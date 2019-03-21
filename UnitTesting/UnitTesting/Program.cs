using System;

namespace UnitTesting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool execute = true;
            string userSelection;
            decimal currentBalance = 2000.32659M;

            Console.WriteLine("Welcome to Bank of CF!");
            Console.WriteLine();
            userSelection = displayMenu();

            do
            {

                if (userSelection.ToUpper() == "1" || userSelection.ToUpper() == "VIEW BALANCE" || userSelection.ToUpper() == "VIEW" || userSelection.ToUpper() == "BALANCE")
                {
                    displayBalance(currentBalance, Convert.ToString(currentBalance));
                    userSelection = displayMenu();
                }

                else if (userSelection.ToUpper() == "2" || userSelection.ToUpper() == "WITHDRAW MONEY" || userSelection.ToUpper() == "WITHDRAW" || userSelection.ToUpper() == "WITHDRAWAL")
                {
                    try
                    {
                        Console.WriteLine("How much would you like to withdraw?");
                        string withdrawalInput = Console.ReadLine();

                        string returnedValue = withdrawMoney(currentBalance, withdrawalInput);
                        currentBalance = displayBalance(currentBalance, returnedValue);
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine($"Something went wrong: {e}");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        displayBalance(currentBalance, Convert.ToString(currentBalance));
                    }
                    finally
                    {
                        userSelection = displayMenu();
                    }
                }

                else if (userSelection.ToUpper() == "3" || userSelection.ToUpper() == "ADD MONEY" || userSelection.ToUpper() == "ADD" || userSelection.ToUpper() == "DEPOSIT")
                {
                    try
                    {
                        Console.WriteLine("How much would you like to deposit?");
                        string depositInput = Console.ReadLine();

                        string returnedValue = addMoney(currentBalance, depositInput);
                        currentBalance = displayBalance(currentBalance, returnedValue);
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine($"Something went wrong: {e}");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        displayBalance(currentBalance, Convert.ToString(currentBalance));
                    }
                    finally
                    {
                        userSelection = displayMenu();
                    }
                }

                else if (userSelection.ToUpper() == "4" || userSelection.ToUpper() == "EXIT" || userSelection.ToUpper() == "QUIT" || userSelection.ToUpper() == "CLOSE" || userSelection.ToUpper() == "END")
                {
                    execute = false;
                }

                else
                {
                    Console.WriteLine("Please make a valid selection.");
                    userSelection = Console.ReadLine();
                }

            } while (execute == true);
        }

        /// <summary>
        /// This method will display the user's current balance at the top of the screen.
        /// If the withdrawMoney or addMoney methods return an error this will display the error instead.
        /// </summary>
        /// <param name="currentBalance">User's current balance.</param>
        /// <param name="returnedValue">Value returned from the withdrawMoney or addMoney methods.</param>
        /// <returns>User's task selection.</returns>
        public static decimal displayBalance(decimal currentBalance, string returnedValue)
        {
            Console.Clear();
            try
            {
                currentBalance = Convert.ToDecimal(returnedValue);

                Console.WriteLine($"Your available balance is: {currentBalance.ToString("C")}");
                return currentBalance;
            }
            catch (FormatException)
            {
                Console.WriteLine($"{returnedValue}");
                return currentBalance;
            }
        }

        /// <summary>
        /// Displays the menu and returns the user's selection.
        /// </summary>
        /// <returns>User's selection.</returns>
        public static string displayMenu()
        {
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
        /// and subtract the amount of their withdrawal, returning their new balance.
        /// The user cannot make negative withdrawals or put their balance into the negative.
        /// </summary>
        /// <param name="balance">User's current balance</param>
        /// <param name="value">Amount of money the user wishes to withdraw.  Cannot be negative.  Cannot be more than balance.</param>
        /// <returns>New balance after withdraw is removed, or an error message if operation fails.</returns>
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

                return newBalance;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (OverflowException)
            {
                throw;
            }
        }

        /// <summary>
        /// This will take the user's current balance as a string, convert it to a decimal,
        /// and add the amount of their deposit, returning their new balance.
        /// The user cannot make negative deposits.
        /// </summary>
        /// <param name="balance">User's current balance.</param>
        /// <param name="value">Amount of money the user wishers to deposit.  Cannot be negative.</param>
        /// <returns>New balance after deposit is added, or an error message if the operation fails.</returns>
        public static string addMoney(decimal balance, string value)
        {
            string newBalance;

            try
            {
                decimal depositValue = Convert.ToDecimal(value);

                if (depositValue < 0)
                {
                    newBalance = "Cannot deposit a negative amount.";
                }
                else
                {
                    newBalance = Convert.ToString(balance + depositValue);
                }

                return newBalance.ToString();
            }
            catch (FormatException)
            {
                throw;
            }
            catch (OverflowException)
            {
                throw;
            }
        }
    }
}
