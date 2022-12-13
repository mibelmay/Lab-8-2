using System;
using System.Security.Principal;

namespace BankAccount
{
    public static class Program
    {
        public static void Main()
        {
            string path = Environment.CurrentDirectory.ToString() + "/account.txt";
            string[] file = File.ReadAllLines(path);
            Account account = new Account(int.Parse(file[0]));
            List<Operation> operations = LoadActions.LoadBankAccount(file);

            foreach (Operation operation in operations)
                Console.WriteLine(operation);
        }
    }
}