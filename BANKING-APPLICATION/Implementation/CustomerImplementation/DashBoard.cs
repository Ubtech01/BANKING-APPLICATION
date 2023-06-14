using BANKING_APPLICATION.Interface.Account_Interface;
using BANKING_APPLICATION.Interface.CustomerInterface;
using BANKING_APPLICATION.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKING_APPLICATION.Implementation.CustomerImplementation
{
    internal class DashBoard : IDashBoard
    {


        private readonly ICreateAccount _createAccount;
        private readonly IDeposit _deposit;
        private readonly IWithdrawal _withdraw;
        private readonly ITransfer _transfer;
        public DashBoard(ICreateAccount createAccount, IDeposit deposit, IWithdrawal withdraw, ITransfer transfer)
        {
            _createAccount = createAccount;
            _deposit = deposit;
            _withdraw = withdraw;
            _transfer = transfer;
        }

       

        public void MyDashBoard(Customer UserLoggedIn)
        {


            Console.WriteLine($"---{UserLoggedIn.Name}'s--DASHBOARD------\n");
            Console.WriteLine($"Welcome, dear {UserLoggedIn.Name} .\nWhat would you like to do today ?\n");
            Console.WriteLine(">Press 1 Create Account");
            Console.WriteLine(">Press 2 to Deposit");
            Console.WriteLine(">Press 3 to Withdraw");
            Console.WriteLine(">Press 4 Transfer");
            Console.WriteLine("Press 5 to get balance");
            Console.WriteLine("Press 6 to get your Statement");
            Console.WriteLine("Press 7 to Logout\n\n");
            Console.Write("Select an option: ");


            string mychoice;
            bool isValidChoice = false;

            do
            {
                mychoice = Console.ReadLine()!;

                if (mychoice == "1")
                {
                    _createAccount.CreateNewAccount(UserLoggedIn);
                    MyDashBoard(UserLoggedIn);
                    isValidChoice = true;
                }
                else if (mychoice == "2")
                {
                    _deposit.DepositMoney(UserLoggedIn);
                    MyDashBoard(UserLoggedIn);
                    isValidChoice = true;
                }
                else if (mychoice == "3")
                {
                    _withdraw.WithdrawMoney(UserLoggedIn);
                    MyDashBoard(UserLoggedIn);
                    isValidChoice = true;
                }
                else if (mychoice == "4")
                {
                    _transfer.TransferMoney(UserLoggedIn);
                    MyDashBoard(UserLoggedIn);
                    isValidChoice = true;
                }
                else if (mychoice == "5")
                {
                    //_myAccService.CheckAccountBalance();

                    isValidChoice = true;
                }
                else if (mychoice == "6")
                {
                    //_myAccService.PrintAccountStatement();

                    isValidChoice = true;
                }

                else if (mychoice == "7")
                {
                    //_userService.LogMeOut();
                    isValidChoice = true;
                }

            } while (isValidChoice);
        }
    }
}
