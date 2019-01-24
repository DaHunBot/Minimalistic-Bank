using System;
/*
 * Creating simple methods to print the menus instead 
 * Has methods to check the transaction log, deposit money, and withdraw money
 */
namespace Minimalistic_Bank
{
    internal class Transactions
    {
        //Shows Transaction Log from most recent to least recent
        public static void ShowTransactionLog(Account account)
        {
            Console.WriteLine("TRANSACTION LOG\n");
            int logLength = account.TransactionLog.Count;
            for (int i = 0; i < logLength; i++)
            {
                Console.WriteLine(account.TransactionLog[logLength - 1 - i]);
            }
        }

        //Deposit Money
        public static void Deposit(Account account)
        {
            //Try Catch to avoid overflow and format exceptions
            try
            {
                //Converts string to decimal 
                decimal deposit = Convert.ToDecimal(Console.ReadLine());
                //if loop to make sure the user is depositing a number that is valid i.e., not negative
                if (deposit >= 0)
                {
                    account.Balance += deposit;
                    string transaction = "Deposited $" + deposit;
                    account.TransactionLog.Add(transaction);
                    Console.WriteLine(transaction);
                }
                else
                {
                    Console.WriteLine("Deposit Invalid, Try Again");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("ERROR: TOO MUCH MONEY DEPOSITED");
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: NUMBERS ONLY and ONE DECIMAL ALLOWED");
            }
        }

        //Withdraw Money
        public static void Withdraw(Account account)
        {
            //Try Catch to avoid overflow and format exceptions
            try
            {
                //Converts string to decimal 
                decimal withdraw = Convert.ToDecimal(Console.ReadLine());
                //if loop to make sure the user is withdrawing a number that is valid ie, not negative and cant withdraw if you have zero
                if (withdraw <= account.Balance)
                {
                    account.Balance -= withdraw;
                    string transaction = "Withdrew $" + withdraw;
                    account.TransactionLog.Add(transaction);
                    Console.WriteLine(transaction);
                }
                else
                {
                    Console.WriteLine("Withdraw Invalid, Try Again");
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("ERROR: TOO MUCH MONEY WITHDRAWN");
            }
            catch (FormatException)
            {
                Console.WriteLine("ERROR: NUMBERS ONLY and ONE DECIMAL ALLOWED");
            }
        }
    }
}