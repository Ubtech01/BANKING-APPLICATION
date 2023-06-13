using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKING_APPLICATION.Interface.CustomerInterface;

namespace BANKING_APPLICATION.Implementation.CustomerImplementation
{
    internal class Login : ILogin
    {
        public void LogMeIn()
        {
            Console.WriteLine("---------------login portal-------------\n");

            Console.Write("Enter your email: ");
            var email = Console.ReadLine();

            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            Console.WriteLine("Login successful");


        }

    }
}
