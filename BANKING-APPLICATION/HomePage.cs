using BANKING_APPLICATION.Interface.CustomerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BANKING_APPLICATION
{
    internal class HomePage
    {
        IRegCustomer _reg;
        ILogin _log;

        public HomePage(IRegCustomer reg, ILogin log)
        {
            _reg = reg;  
            _log = log;
        }

        public void MyHomePage()
        {
            Console.WriteLine("Welcome to your Bank Application");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            string? input = Console.ReadLine();

            if (input == "1")
            {
                //Registeration
               // var reg = new IRegCustomer();
                _reg.RegCustomerFunc();
            
            }
            else if (input == "2") 
            {
              _log.LogMeIn();
            }

        }
    }
}
