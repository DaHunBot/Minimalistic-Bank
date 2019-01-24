using System;
using System.Collections.Generic;
/*
 * ACCOUNT CLASS
 * Holds Username, Password, Balance, TransactionLog (ACCOUNT DETAILS)
 * Holds Methods to create new accounts, check login info, and a simple masking password for login
 */
namespace Minimalistic_Bank
{
    internal class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public List<string> TransactionLog { get; set; }

        //Creates new account
        public static Account NewAccount(List<Account> accounts)
        {
            //Set new username for account
            string userName = "";
            while (userName == "")
            {
                bool validName = true;
                Console.WriteLine("Enter Username: ");
                string pickedName = Console.ReadLine();

                //Checks to see if account name is already taken
                foreach (Account account in accounts)
                {
                    if (account.Username == pickedName)
                    {
                        validName = false;
                    }
                }
                if (validName)
                {
                    userName = pickedName;
                }
                else
                {
                    Console.WriteLine("Username is already taken.");
                }
            }
            //Set new password for account
            string password = "";
            while (password == "")
            {
                Console.WriteLine("Enter Password: ");
                string pickedPass = Console.ReadLine();
                password = pickedPass;
            }
            List<string> newTransactionLog = new List<string> { };
            Account newAccount = new Account { Username = userName, Password = password, Balance = 0, TransactionLog = newTransactionLog };
            return newAccount;


        }

        //Login with account details
        public static Account Login(List<Account> accounts)
        {
            Console.WriteLine("Enter Username:");
            string userName = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string password = MaskPassword(); //Masking Password

            //if Login info matches then accountActive is no longer null
            Account accountActive = null;
            foreach (Account account in accounts)
            {
                if (account.Username == userName && account.Password == password)
                {
                    accountActive = account;
                }
            }
            return accountActive;
        }

        //Masks password during login
        public static string MaskPassword()
        {
            string hidePass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    hidePass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && hidePass.Length > 0)
                    {
                        hidePass = hidePass.Substring(0, (hidePass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            while (true);
            Console.WriteLine("");
            return hidePass;
        }
    }
}