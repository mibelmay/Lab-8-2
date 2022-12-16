using System;
using System.Collections.Generic;


namespace BankAccount
{
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

                line[1].Trim(' ');
                if (line.Length == 2)
                {
                    result.Add(new Operation(data, "revert"));
                    continue;
                }

                int amount = int.Parse(line[1]);
                string action = line[2].Trim();
                result.Add(new Operation(data, amount, action));

            }

            for (int i = 1; i < result.Count; i++)
            {
                for (int j = 0; j < result.Count - 1; j++)
                {
                    if (result[j].Date > result[j + 1].Date)
                    {
                        Operation temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }
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
