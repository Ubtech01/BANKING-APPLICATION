using BANKING_APPLICATION.Models.CustomerModel;

namespace BANKING_APPLICATION.Interface.Account_Interface
{
    internal interface IWithdrawal
    {
        void WithdrawMoney(Customer UserLoggedIn);
    }
}