using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BANKING_APPLICATION.Interface.CustomerInterface;
using BANKING_APPLICATION.Models.CustomerModel;

namespace BANKING_APPLICATION.Implementation.CustomerImplementation
{
    internal class Login :RegisterationHelper , ILogin
    {
        private IDashBoard _dash;
        public Login(IDashBoard dash)
        {
            _dash = dash;
        }
        public void LogMeIn()
        {

            List<Customer> customers = ReadCustomersFromFile("Customers.txt");
            string emailFormat = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            string passwordFormat = @"^(?=.*[a-zA-Z0-9])(?=.*[@#$%^&+=])(?=.{6,})";
            string email;
            string password;

            Console.WriteLine("--------------Welcome to your login portal------------\n");

            do
            {
                Console.WriteLine("Email should be in the correct format");
                Console.Write("Enter your email: ");
                 email = Console.ReadLine()!;
            }
            while (!Regex.IsMatch(email, emailFormat));

            do {
                Console.WriteLine("Password should not be less than 6 characters and must have a special character e.g !@#*");
                Console.Write("Enter your password: ");
                password = Console.ReadLine()!;
            }
            while (!Regex.IsMatch(password, passwordFormat));

            /*---------------------------------------------------------------------*/

            Customer? UserLoggedIn = customers.FirstOrDefault(c => c.Email == email && c.Password == password);

            if (UserLoggedIn != null)
            {
                Console.Clear();
                Console.WriteLine("Successfully Logged in!");
                _dash.MyDashBoard(UserLoggedIn);
            }
            else
            {
                Console.WriteLine("\n\nInvalid email or password.");
                Console.WriteLine("Please try again or register a new account.");
            }
        }

    }

}
