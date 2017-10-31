using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace SupportBank
{
    class Program
    {
        static AccountsManager _manager;

        static void Main(string[] args)
        {
            SetupAccountsManager();
            GetUserCommand();

            Console.ReadLine();

        }

        private static void SetupAccountsManager()
        {
            try
            {
                _manager = new AccountsManager("Transactions2014.csv");
            }
            catch (Exception ex)
            {
                Console.Write($"Error while importing transactions and creating accounts: {ex.Message}");
            }
        }

        private static void GetUserCommand()
        {  
            bool isValidCommand = true;
            Regex regex = new Regex(@"^list ([a-z\s]+)", RegexOptions.IgnoreCase);

            do
            {
                Console.Write("Enter command: ");
                string enteredCommand = Console.ReadLine();

                if(regex.IsMatch(enteredCommand))
                {
                    isValidCommand = true;
                    string commandArg = regex.Match(enteredCommand).Groups[1].Value.ToLower();

                    switch(commandArg)
                    {
                        case "all":
                            PrintBalanceForEveryAccount();
                            break;
                        default:
                            isValidCommand = PrintTransactionsOfNamedAccount(commandArg);
                            break;                         
                    }
                }
                else
                {
                    isValidCommand = false;
                    Console.WriteLine("Invalid command. Try again.");
                }
                
            }
            while (!isValidCommand);
        }

        private static void PrintBalanceForEveryAccount()
        {
            Console.WriteLine(string.Join("\n", _manager.GetBalanceForEveryAccount()));
        }

        private static bool PrintTransactionsOfNamedAccount(string name)
        {
            Account acc = _manager.GetAccountByName(name);

            if (acc == null)
            {
                Console.WriteLine($"No account found for {name}. Try again.");
                return false;
            }

            Console.WriteLine($"\n***All Transactions found for {acc.Name}***");

            Console.WriteLine($"\n>Credit");
            Console.WriteLine(string.Join("\n", acc.GetCreditTransactionsAsFormattedStrings()));

            Console.WriteLine($"\n>Debit");
            Console.WriteLine(string.Join("\n", acc.GetDebitTransactionsAsFormattedStrings()));

            return true;
        }

    }
}
