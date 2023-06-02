using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeeperPRO.Pages.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using RegisterUnitCase.ADO;

namespace KeeperPRO.Pages.Auth.Tests
{
    [TestClass()]
    public class RegisterPageTests
    {
        [TestMethod()]
        public void RegisterPageTest()
        {
            User newUser = new User
            {
                Email = "testEmail@gmail.com",
                EncPassword = SHA512("password"),
                RoleCode = 1,
                FirstName = "Шубина",
                LastName = "Тамара",
                SurName = "Яковна",
                Login = "testEmail"
            };

            DBConnections.DB.User.Add(newUser);
            DBConnections.DB.SaveChanges();

            Assert.IsTrue(newUser.ID != 0);
        }

        public static string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }


    }
}