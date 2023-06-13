using BANKING_APPLICATION.Implementation.CustomerImplementation;
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

            var serviceProvider =  services.BuildServiceProvider();
            var home = serviceProvider.GetRequiredService<HomePage>();

            home.MyHomePage();
        }
    }
}