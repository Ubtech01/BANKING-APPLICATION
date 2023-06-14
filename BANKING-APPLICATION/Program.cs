using BANKING_APPLICATION.Implementation.Account_Implementation;
using BANKING_APPLICATION.Implementation.CustomerImplementation;
using BANKING_APPLICATION.Interface.Account_Interface;
using BANKING_APPLICATION.Interface.CustomerInterface;
using BANKING_APPLICATION.Models.CustomerModel;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;

namespace BANKING_APPLICATION
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            var services = new ServiceCollection();

            services.AddSingleton<HomePage>();
            services.AddScoped<IRegCustomer, RegCustomer>();
            services.AddScoped<ILogin, Login>();

            services.AddScoped<IDashBoard, DashBoard>(); 
            services.AddScoped<ICreateAccount, CreateAccount>();
            services.AddScoped<IDeposit, Deposit>();
            services.AddScoped<IWithdrawal, Withdrawal>();
            services.AddScoped<ITransfer, Transfer>();

            var serviceProvider =  services.BuildServiceProvider();
            var home = serviceProvider.GetRequiredService<HomePage>();

            home.MyHomePage();
        }
    }
}