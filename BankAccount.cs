using System;

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
     
    
}
