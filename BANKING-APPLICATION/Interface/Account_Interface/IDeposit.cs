using BANKING_APPLICATION.Models.CustomerModel;

namespace BANKING_APPLICATION.Interface.Account_Interface
{
    public interface IDeposit
    {
        void DepositMoney(Customer UserLoggedIn);
    }
}