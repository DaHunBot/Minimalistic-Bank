using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/* AltSource Prompt
   You have been tasked with writing the world’s greatest banking ledger. 
   Please code a solution that can perform the following workflows through a console application (accessed via the command line):
    
    -Create a new account
    -Login
    -Record a deposit
    -Record a withdrawal
    -Check balance
    -See transaction history
    -Log out

   For additional credit, you may implement this through a web page. They don’t have to run at the same time, but if you would like to do that, feel free.

   Use C# for the backend. If designing a front end, use whatever JavaScript frameworks/libraries you wish and just make sure they are included or available via NuGet. 
   There is no need to use persistent storage or spend much time on the UI (unless you love doing that).

    No persistent storage. Only remembers login info from that session.
    Created by David Huynh 1/22/2019
*/

namespace Minimalistic_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a list of accounts
            List<Account> accounts = new List<Account> { };

            //To see if any account is logged in
            Account accountActive = null;

            //Start Menu
            Menus.StartMenu();

            //Keeps the cmd prompt open until "Quit" changes it to false
            bool appActive = true;

            while (appActive)
            {
                //Regex to ignore white space
                Regex whiteSpace = new Regex(" ");
                string input = whiteSpace.Replace(Console.ReadLine(), "");

                /*
                 * Checks to see if any account is active
                 * Number inputs will do 2 sets of things based on if an account is active
                 */
                if (accountActive != null)
                {
                    //Balance
                    if (input == "1")
                    {
                        Console.WriteLine("Current Balance: $" + accountActive.Balance);
                    }
                    //Transaction Log
                    else if (input == "2")
                    {
                        Transactions.ShowTransactionLog(accountActive);
                    }
                    //Deposit Money
                    else if (input == "3")
                    {
                        Console.WriteLine("Deposit Amount:");
                        Transactions.Deposit(accountActive);
                    }
                    //Withdraw Money
                    else if (input == "4")
                    {
                        Console.WriteLine("Withdraw Amount:");
                        Transactions.Withdraw(accountActive);
                    }
                    //Logout
                    else if (input == "5")
                    {
                        accountActive = null;
                        Console.Clear();
                        Menus.StartMenu();
                    }
                    //Displays menu if 1-5 is not chosen
                    else
                    {
                        Console.WriteLine("\nEnter a number\n");
                        Menus.AccountOptions();
                    }
                }
                //If there isnt any active accounts
                else
                {
                    //Login
                    if (input == "1")
                    {
                        accountActive = Account.Login(accounts);
                        if (accountActive != null)
                        {
                            //display menu on login
                            Console.Clear();
                            Menus.AccountOptions();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Login Info, Enter 1 to Try Again");
                        }
                    }
                    //Sign Up
                    else if (input == "2")
                    {
                        accounts.Add(Account.NewAccount(accounts));
                        Console.WriteLine("Thanks for Signing Up! Enter 1 to Login");
                    }

                    //Quit
                    else if (input == "3")
                    {
                        appActive = false;
                    }
                    //Displays menu if 1-3 is not selected
                    else
                    {
                        Console.WriteLine("\nPick 1, 2, or 3\n");
                        Menus.StartMenu();
                        
                    }
                }
            }

        }
    }
}
