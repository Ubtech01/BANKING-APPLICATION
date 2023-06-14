using BANKING_APPLICATION.Models.CustomerModel;

namespace BANKING_APPLICATION.Interface.Account_Interface
{
    public interface ICreateAccount
    {
        void CreateNewAccount(Customer UserLoggedIn);
    }
}