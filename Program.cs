using System;
using System.Security.Principal;

namespace BankAccount
{
    static class Program
    {
        static void Main()
        {
            string path = Environment.CurrentDirectory.ToString() + "/account.txt";

            CheckFile(path);

            string[] file = File.ReadAllLines(path);
            Account account = new Account(int.Parse(file[0]));
            List<Operation> operations = LoadActions.LoadBankAccount(file);



            Console.WriteLine("Введите дату в формате yyyy-mm-dd hh:mm\n");
            string input = Console.ReadLine();
            Console.WriteLine();
            DateTime date = LoadActions.GetDate(input);
            Console.Write($"Состояние счета на момент {input} : {GetSum(date, account, operations)}\n");

        }

        public static void CheckFile(string path) 
        {
            string[] file = File.ReadAllLines(path);
            Account account = new Account(int.Parse(file[0]));
            List<Operation> operations = LoadActions.LoadBankAccount(file);

            if (GetSum(operations[operations.Count - 1].Date, account, operations) < 0) 
            {
                throw new Exception("File is not correct");
            }
        }
        public static int GetSum(DateTime input, Account account, List<Operation> operations)
        {
            
            for (int i = 0; i < operations.Count; i++)
            {
                if (input < operations[i].Date)
                {
                    return account.Sum;
                }
                if (operations[i].Action == "in")
                {
                    account.In(operations[i].Amount);
                }
                else if (operations[i].Action == "out")
                {
                    account.Out(operations[i].Amount);
                }
                else if (operations[i].Action == "revert")
                {
                    account.Revert(operations[i - 1]);
                }
            }
            return account.Sum;

        }
    }
}