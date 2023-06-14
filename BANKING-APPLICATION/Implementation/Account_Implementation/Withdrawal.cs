﻿using BANKING_APPLICATION.Interface.Account_Interface;
using BANKING_APPLICATION.Models.AccountModel;
using BANKING_APPLICATION.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKING_APPLICATION.Implementation.Account_Implementation
{
    internal class Withdrawal : AccountHelper, IWithdrawal
    {
        private string? AmountToWithdraw { get; set; }
        private string? AccountToWithdrawFrom { get; set; }
        private decimal CleanAmountToWithdraw { get; set; }



        public void WithdrawMoney(Customer UserLoggedIn)
        {
            Console.Clear();
            List<Account> accounts = ReadAccountsFromFile("Accounts.txt");

            ShowAllAccount(UserLoggedIn);
            Console.Write("Here are your accounts above.\n Type in the account number you want to WithDraw from>>.");
            AccountToWithdrawFrom = Console.ReadLine();

            Console.Write("Enter the amount you want to Withdraw>>");
            AmountToWithdraw = Console.ReadLine();
            CleanAmountToWithdraw = decimal.Parse(AmountToWithdraw);

            List<Account> UserLoggedInAccounts = accounts.Where(account => account.Id == UserLoggedIn.Id).ToList();

            Account? accountToUpdate = UserLoggedInAccounts.FirstOrDefault(account => account.AccountNumber == AccountToWithdrawFrom);

            if (accountToUpdate is null)
            {
                Console.Clear();
                Console.WriteLine("\n\nThe account entered does not exist!\nPlease enter a valid account number\n");
            }
            else if (accountToUpdate.AccountType == "savings" && accountToUpdate.Balance < 1001)
            {
                Console.Clear();
                Console.WriteLine("\n\nUnable to withdraw. There should be a minimum of 1000 naira in your savings account \n");

            }
            else if (accountToUpdate.Balance < CleanAmountToWithdraw)
            {
                Console.Clear();
                Console.WriteLine("\n\nInsufficient Funds!, Kindly try a lesser amount.\n");

            }
            else if (accountToUpdate.Balance < 1)
            {
                Console.Clear();
                Console.WriteLine("\n\nInsufficient Funds!.\n");

            }
            else
            {
                accountToUpdate.Balance -= CleanAmountToWithdraw;
                Console.WriteLine($"\nYou have successfully withdrawn {CleanAmountToWithdraw} from your account with account number {AccountToWithdrawFrom}");
            }

            // Update the Account.txt file with the new balance
            using (StreamWriter writer = new StreamWriter("Accounts.txt"))
            {
                foreach (var account in accounts)
                {
                    writer.WriteLine($"| {account.Id,-12} | {account.Name,-12} | {account.AccountNumber,-12} | {account.AccountType,-8} | {account.Balance} |");
                }
            }
        }
    }
}
