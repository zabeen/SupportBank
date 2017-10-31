using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountsManager manager = new AccountsManager("Transactions2014.csv");

            Console.ReadLine();

        }



    }
}
