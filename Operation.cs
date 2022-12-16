using System;
using System.Collections.Generic;

namespace BankAccount
{
    class Operation
    {
        public DateTime Date { get; private set; }
        public int Amount { get; private set; }
        public string Action { get; private set; }

        public Operation(DateTime date, int amount, string action)
        {
            Date = date;
            Amount = amount;
            Action = action;
        }

        public Operation(DateTime date, string action)
        {
            Date = date;
            Action = action;
        }

    }
}
