using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Account
    {
        public ulong Balance { get; set; }
        public string AccountType { get; set; } //Savings,Checking

        public Account(ulong initialBalance, string accountType)
        {
            Balance = initialBalance;
            AccountType = accountType;
        }

        public ulong Deposit(ulong amount)
        {
            Balance += amount;
            return Balance;
        }
        public ulong Withdraw(ulong amount)
        {
            Balance -= amount;
            return Balance;
        }

    }
}
