using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKING_APPLICATION.Interface.CustomerInterface;
using BANKING_APPLICATION.Models.CustomerModel;

namespace BANKING_APPLICATION.Implementation.CustomerImplementation
{
    internal class Login :RegisterationHelper , ILogin
    {
        public void LogMeIn()
        {

            List<Customer> customers = ReadCustomersFromFile("Customers.txt");
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            string passwordPattern = @"^(?=.*[a-zA-Z0-9])(?=.*[@#$%^&+=])(?=.{6,})";
            string myemail;
            string mypassword;

            Console.WriteLine("--------------login portal------------\n");

            Console.Write("Enter your email: ");
            var email = Console.ReadLine();

            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            Console.WriteLine("Login successful");


        }

    }
}
