using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{

    class Operation
    {
        public int Date { get; private set; }
        public int Time { get; private set; }
        public int Amount { get; private set; }
        public string Action { get; private set; }

        public Operation(int date, int time, int amount, string action)
        {
            Date = date;
            Time = time;
            Amount = amount;
            Action = action;
        }

        public Operation(int date, int time, string action)
        {
            Date = date;
            Time = time;
            Action = action;
        }

        public int In()
        {
            return Amount;
        }

        public int Out()
        {
            return Amount * -1;
        }

        public override string ToString()
        {
            return $"{Date}, {Time}, {Amount}, {Action}";
        }
    }
    class LoadActions
    {
        public static Operation[] LoadBankAccount(string[] file)
        {
            Operation[] result = new Operation[file.Length - 1];
            for (int i = 1; i < file.Length; i++)
            {
                string[] line = file[i].Split('|');
                line[0].Trim();
                int date = int.Parse((String.Join("", (line[0].Split(' '))[0].Split('-'))));
                int time = int.Parse((String.Join("", (line[0].Split(' '))[1].Split(':'))));

                line[1].Trim();
                if (line.Length == 2)
                {

                    result[i - 1] = new Operation(date, time, line[1]);
                    continue;
                }
                
                int amount = int.Parse(line[1]);
                string action = line[2].Trim();
                result[i - 1] = new Operation(date, time, amount, action);

            }
            return result;
        }
    }
}
