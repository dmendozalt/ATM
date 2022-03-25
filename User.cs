using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class User
    {
        public string Name { get; set; }
        public ushort Password { get; set; }
        public Dictionary<int,Account> Accounts { get; set; }

        public User(string name, ushort password) 
        {
            Name = name;
            Password = password;
            Accounts = new Dictionary<int, Account>();
            Accounts.Add(1, new Account(0, "Savings"));
        }

        public void AddAccount(ulong initialBalance,string accountType)
        {
            Accounts.Add(Accounts.Count+1, new Account(initialBalance, accountType));
        }

        public void ShowAccounts()
        {
            foreach (var item in Accounts)
                Console.WriteLine($"\n {item.Key}.Cuenta de tipo: {item.Value.AccountType}   ${item.Value.Balance}");
        }
    }
}
