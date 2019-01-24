using System;
/*
 * Creating simple methods to print the menus instead 
 * of copying and pasting the same writelines in 
 * several if and else statements
 */
namespace Minimalistic_Bank
{
    internal class Menus
    {
        public static void StartMenu()
        {
            Console.WriteLine("MINIMALISTIC BANK\n");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. Quit");
        }

        public static void AccountOptions()
        {
            Console.WriteLine("ACCOUNT DETAILS\n");
            Console.WriteLine("1. Balance");
            Console.WriteLine("2. Transaction Log");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Log Out");
        }
    }
}