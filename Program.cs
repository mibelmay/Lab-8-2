using System;
using System.Security.Principal;

namespace BankAccount
{
    public static class Program
    {
        public static void Main()
        {
            int initialAccount;
            string path = Environment.CurrentDirectory.ToString() + "/account.txt";
            string[] file = File.ReadAllLines(path);
            initialAccount = Convert.ToInt32(file[0]);
            Operation[] operations = LoadActions.LoadBankAccount(file);

            foreach (Operation operation in operations)
                Console.WriteLine(operation);
        }
    }
}