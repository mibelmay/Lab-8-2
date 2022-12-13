﻿using System;
using System.Security.Principal;

namespace BankAccount
{
    static class Program
    {
        static void Main()
        {
            string path = Environment.CurrentDirectory.ToString() + "/account.txt";
            string[] file = File.ReadAllLines(path);
            Account account = new Account(int.Parse(file[0]));
            List<Operation> operations = LoadActions.LoadBankAccount(file);

            GetSum(operations[operations.Count - 1].Date, account, operations); //проверка корректности файла

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

                }
            }
            if (account.Sum < 0)
            {
                throw new Exception("File is not correct");
            }
            return account.Sum;

        }
    }
}