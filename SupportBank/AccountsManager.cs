﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    public class AccountsManager
    {
        private List<Account> _accounts = new List<Account>();
        private List<Transaction> _allTransactions = new List<Transaction>();

        public AccountsManager(string filePath)
        {
            ImportTransactionsFromFile(filePath);
            CreateAccounts();
        }

        private void ImportTransactionsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                // read in file contents, skipping over first header line, and split each line by comma delimiter
                List<string[]> lines = File.ReadLines(filePath).Skip(1).Select(line => line.Split(',')).ToList();

                // convert values in each string[] to transaction obj and add to final list
                lines.ForEach(l => _allTransactions.Add(new Transaction(Convert.ToDateTime(l[0]), l[1], l[2], l[3], float.Parse(l[4]))));
            }
        }

        private void CreateAccounts()
        {
            // extract user names listed in 'To' and 'From' fields
            List<string> allNames = new List<string>();
            allNames.AddRange(_allTransactions.Select(t => t.DebitFrom).ToList());
            allNames.AddRange(_allTransactions.Select(t => t.CreditTo).ToList());

            // create accounts from distinct values in names list
            foreach (string name in allNames.Distinct())
            {
                Account acc = new Account(name);

                // add transactions for this acount
                acc.AddCreditTransactions(_allTransactions.Where(t => t.CreditTo == name).ToList());
                acc.AddDebitTransactions(_allTransactions.Where(t => t.DebitFrom == name).ToList());

                _accounts.Add(acc);
            }
        }
    }
}
