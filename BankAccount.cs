using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
     class Account
    {
        public int Sum { get; private set; }

        public Account(int sum)
        {
            Sum = sum;
        }

        public void In(int amount)
        {
            Sum += amount;
        }

        public void Out(int amount)
        {
            Sum -= amount;
        }

        public void Revert(Operation operation)
        {
            if (operation.Action == "in")
            {
                Sum -= operation.Amount;
            }
            else if (operation.Action == "out")
            {
                Sum += operation.Amount;
            }
            else
            {
                throw new Exception("You cannot revert a revert operation");
            }
        }
    }
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

        public override string ToString()
        {
            return $"{Date}, {Amount}, {Action}";
        }
    }
    class LoadActions
    {
        public static List<Operation> LoadBankAccount(string[] file)
        {
            List<Operation> result = new List<Operation>();
            for (int i = 1; i < file.Length; i++)
            {
                string[] line = file[i].Split('|');
                line[0].Trim();

                DateTime data = GetDate(line[0]);
                
                line[1].Trim();
                if (line.Length == 2)
                {

                    result.Add(new Operation(data, line[1]));
                    continue;
                }
                
                int amount = int.Parse(line[1]);
                string action = line[2].Trim();
                result.Add(new Operation(data, amount, action));
                
            }
            result.Sort((x, y) => x.Date.CompareTo(y.Date));
            return result;
        }

        public static DateTime GetDate(string line)
        {
            string[] date = (line.Split(' '))[0].Split('-');
            string[] time = (line.Split(' '))[1].Split(':');

            DateTime data = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), int.Parse(time[0]), int.Parse(time[1]), 0);

            return data;
        }

    }
}
