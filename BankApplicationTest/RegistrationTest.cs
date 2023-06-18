using BANKING_APPLICATION.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;


namespace BankApplicationTest
{
    public class RegistrationTest
    {
        [Fact]
        public void Generate_UserId()
        {
            //Arrange
            RegisterationHelper helper = new RegisterationHelper();

            //Act
            var expected = helper.UserId();

            //Assert
            Assert.NotNull(expected);
            Assert.NotEmpty(expected);
            Assert.Matches(@"^\d+$", expected);
        }

        [Fact]
        public void GetInputed_Valid_UserName()
        {
            //Arrange
            RegisterationHelper helper = new RegisterationHelper();
            var input = "John Doe";
            var inputStream = new StringReader(input);
            Console.SetIn(inputStream);

            //Act
            var expected = helper.UserName();

            //Assert
            Assert.NotNull(expected);
            Assert.NotEmpty(expected);
            Assert.Matches(@"^[A-Z][a-zA-Z]*\s[A-Z][a-zA-Z]*$", expected);
        }

        [Fact]
        public void GetInputed_Valid_UserEmail()
        {
            RegisterationHelper helper = new RegisterationHelper();

            // Arrange
            var input = "test@example.com";
            var inputStream = new StringReader(input);
            Console.SetIn(inputStream);

            // Act
            string useremail = helper.UserEmail(); // Assuming MyClass contains the UserEmail method

            // Assert
            Assert.NotNull(useremail);
            Assert.NotEmpty(useremail);
            Assert.Matches(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", useremail); // Matches a string with a valid email format
        }

        [Fact]
        public void GetInputed_Valid_UserPassword()
        {
            // Arrange
            RegisterationHelper helper = new RegisterationHelper();
            var input = "@23Wasme2";
            var inputStream = new StringReader(input);
            Console.SetIn(inputStream);

            //Act
            string userPassword = helper.UserPassword();


            Assert.NotNull(userPassword);
            Assert.NotEmpty(userPassword);
            Assert.Matches(@"^(?=.*[a-zA-Z0-9])(?=.*[@#$%^&+=])(?=.{6,})", userPassword);
        }
    }
        
}
