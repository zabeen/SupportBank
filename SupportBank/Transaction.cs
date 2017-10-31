using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    public class Transaction
    {
        // read only props
        public DateTime Date { get; }
        public string DebitFrom { get; }
        public string CreditTo { get; }
        public string Narrative { get; }
        public float Amount { get; }

        public Transaction(DateTime date, string debitFrom, string creditTo, string narrative, float amount)
        {
            // can only set props at create time
            Date = date;
            DebitFrom = debitFrom;
            CreditTo = creditTo;
            Narrative = narrative;
            Amount = amount;
        }
    }
}
