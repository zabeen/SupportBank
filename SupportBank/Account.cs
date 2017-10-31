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
        public float CreditTotal { get { return CalculateCreditTotal(); } }
        public float DebitTotal { get { return CalculateDebitTotal(); } }
        public float Balance { get { return CalculateBalance(); } }

        private List<Transaction> _creditTransactions = new List<Transaction>();
        private List<Transaction> _debitTransactions = new List<Transaction>();

        public Account(string name)
        {
            Name = name;
        }

        public List<string> GetCreditTransactionsAsFormattedStrings()
        {
            return _creditTransactions.Select(c => $"{_creditTransactions.IndexOf(c)+1}: Borrowed {c.Amount:C} from {c.DebitFrom} on {c.Date.ToShortDateString()} for {c.Narrative}").ToList();
        }

        public List<string> GetDebitTransactionsAsFormattedStrings()
        {
            return _debitTransactions.Select(d => $"{_debitTransactions.IndexOf(d)+1}: Lent {d.Amount:C} to {d.CreditTo} on {d.Date.ToShortDateString()} for {d.Narrative}").ToList();
        }

        public void AddCreditTransactions(List<Transaction> transactions)
        {
            _creditTransactions.AddRange(transactions);
        }

        public void AddDebitTransactions(List<Transaction> transactions)
        {
            _debitTransactions.AddRange(transactions);
        }

        private float CalculateCreditTotal()
        {
            return _creditTransactions.Sum(o => o.Amount);
        }

        private float CalculateDebitTotal()
        {
            return _debitTransactions.Sum(o => o.Amount);
        }
        private float CalculateBalance()
        {
            return CreditTotal - DebitTotal;
        }
    }
}
