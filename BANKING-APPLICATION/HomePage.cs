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
            string input;
            do {
                Console.WriteLine("Welcome to your Bank Application\n");
                Console.WriteLine("Select from 1-3");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Logout");
                input = Console.ReadLine()!;

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
                if (input == "3")
                {
                    Console.WriteLine("Thank you for banking with us");
                    Environment.Exit(0);

                }
            }
            while (/*!int.TryParse(input, out _) ||*/ int.Parse(input) != 1 || int.Parse(input) != 2 || int.Parse(input) != 3);
            {

            }
        }
    }
}
