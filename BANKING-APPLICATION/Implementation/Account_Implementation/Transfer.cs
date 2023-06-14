using BANKING_APPLICATION.Interface.Account_Interface;
using BANKING_APPLICATION.Models.AccountModel;
using BANKING_APPLICATION.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKING_APPLICATION.Implementation.Account_Implementation
{
    internal class Transfer : AccountHelper, ITransfer
    {


        //transfer fields
        private string? AccountToTransferTo { get; set; }
        private string? AccountToTransferFrom { get; set; }
        private decimal CleanAmountToTransfer { get; set; }


        public void TransferMoney(Customer UserLoggedIn)
        {
            Console.Clear();

            List<Account> accounts = ReadAccountsFromFile("Accounts.txt");
            List<Account> UserLoggedInAccounts = accounts.Where(account => account.Id == UserLoggedIn.Id).ToList();

            ShowAllAccount(UserLoggedIn);
            Console.WriteLine("----------Transfers-----------");
            Console.Write("\nEnter the account number you are  TRANSFERING FROM:>> ");

            AccountToTransferFrom = Console.ReadLine();

            Console.Write("Enter the account you want to TRANSFER TO:>> ");
            AccountToTransferTo = Console.ReadLine();

            Console.Write("Enter the amount you want to transfer:>> ");
            string? AmountToTransfer = Console.ReadLine();

            CleanAmountToTransfer = decimal.Parse(AmountToTransfer);

            Account? giver = UserLoggedInAccounts.FirstOrDefault(account => account.AccountNumber == AccountToTransferFrom);
            Account? receiver = UserLoggedInAccounts.FirstOrDefault(account => account.AccountNumber == AccountToTransferTo);



            if (giver != null && receiver != null && giver.AccountType == "savings" && giver.Balance > CleanAmountToTransfer + 1000)
            {
                giver.Balance -= CleanAmountToTransfer;
                receiver.Balance += CleanAmountToTransfer;
                Console.WriteLine($"{CleanAmountToTransfer} has been Sent to {AccountToTransferTo} successfully!");
            }
            else if (giver != null && receiver != null && giver.AccountType == "current" && giver.Balance > CleanAmountToTransfer)
            {
                giver.Balance -= CleanAmountToTransfer;
                receiver.Balance += CleanAmountToTransfer;
                Console.WriteLine($"{CleanAmountToTransfer} has been Sent to {AccountToTransferTo} successfully!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"\n\nError in Transaction!\n\n");
            }
            // Update the Account.txt file with the new objects
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
