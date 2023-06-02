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
        public void RegisterSaveDBTest()
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



        [TestMethod()]
        public void RegisterValidateDBTest()
        {

            string password = "Zz8POQlP}M4~";

            if (!IsValidatePassword(password))
            {
                Assert.IsTrue(IsValidatePassword(password));
                return;
            }
            

            User newUser = new User
            {
                Email = "test2Email@gmail.com",
                EncPassword = SHA512(password),
                RoleCode = 1,
                FirstName = "Зиновьева",
                LastName = "Таисия",
                SurName = "Яковна",
                Login = "test2Email"
            };

            DBConnections.DB.User.Add(newUser);
            DBConnections.DB.SaveChanges();

            Assert.IsTrue(newUser.ID != 0);
        }



        private static bool IsValidatePassword(string password)
        {
            string message = "";
            if (password.Length < 8)
            {
                message += "Пароль должен иметь как минимум 8 символов!\n";
            }
            if (!password.Any(x => char.IsUpper(x)))
            {
                message += "Пароль должен иметь как минимум 1 символ верхнего регистра!\n";
            }
            if (!password.Any(x => char.IsLower(x)))
            {
                message += "Пароль должен иметь как минимум 1 символ нижнего регистра!\n";
            }
            if (!password.Any(x => char.IsDigit(x)))
            {
                message += "Пароль должен иметь как минимум 1 цифру!\n";
            }
            List<char> specialSymbols = new List<char> {'!','@','#','№','$','%','^',
                '&','*','-','_','?','<','>'};
            if (password.Any(x => specialSymbols.Any(y => x == y)))
            {
                message += "Пароль должен иметь как минимум 1 спецсимвол!\n";
            }
            if (message != "")
            {
                Assert.Fail(message);
                return false;
            }
            return true;
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