using BANKING_APPLICATION.Models.CustomerModel;

namespace BANKING_APPLICATION.Interface.CustomerInterface
{
    internal interface IDashBoard
    {
        void MyDashBoard(Customer UserLoggedIn);
    }
}