using BANKING_APPLICATION.Interface.CustomerInterface;
using BANKING_APPLICATION.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANKING_APPLICATION.Implementation.CustomerImplementation
{
    public class RegCustomer : RegisterationHelper, IRegCustomer
    {
        public void RegCustomerFunc()
        {
            //var id = Guid.NewGuid();
            //Console.WriteLine("Enter your name");
            //string? fullName = Console.ReadLine();

            //Console.WriteLine("Enter your email");
            //string? email = Console.ReadLine();

            //Console.WriteLine("Enter your password");
            //string? password = Console.ReadLine();

            var id = UserId();
            var name = UserName();
            var email = UserEmail();
            var password = UserPassword();

            //Creating customer
            Customer customer = new Customer(id, name, email, password);

            // Adding customer to a file
            using (var writer = new StreamWriter("Customers.txt", true))
            {
                writer.WriteLine($"| {customer.Id} | {customer.Name} | {customer.Email} | {customer.Password}");
            }

            Console.WriteLine($"Congrats, {customer.Name} your program have been written to file");
        }
    }
}
