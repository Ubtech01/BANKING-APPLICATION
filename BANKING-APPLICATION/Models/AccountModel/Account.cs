using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKING_APPLICATION.Models.AccountModel
{
    internal class Account
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }

        public Account(string id, string fullName, string accountNumber, string accountType, decimal balance)
        {
            Name = fullName;
            Id = id;
            AccountNumber = accountNumber;
            AccountType = accountType;
            Balance = balance;
        }
    }
}
