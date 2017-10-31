using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    public class Account
    {
        public string Name { get; }
        public float TotalCredit { get { return CalculateTotalCredit(); } }
        public float TotalDebit { get { return CalculateTotalDebit(); } }

        private List<Transaction> _creditTransactions = new List<Transaction>();
        private List<Transaction> _debitTransactions = new List<Transaction>();

        public Account(string name)
        {
            Name = name;
        }

        public void AddCreditTransactions(List<Transaction> transactions)
        {
            _creditTransactions.AddRange(transactions);
        }

        public void AddDebitTransactions(List<Transaction> transactions)
        {
            _debitTransactions.AddRange(transactions);
        }

        private float CalculateTotalCredit()
        {
            return _creditTransactions.Sum(o => o.Amount);
        }

        private float CalculateTotalDebit()
        {
            return _debitTransactions.Sum(o => o.Amount);
        }

    }
}
