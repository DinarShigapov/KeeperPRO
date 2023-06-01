using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeeperPRO.Pages.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeeperPRO.ADO;

namespace KeeperPRO.Pages.Auth.Tests
{
    [TestClass()]
    public class RegisterPageTests
    {
        [TestMethod()]
        public void RegisterPageTest()
        {
            KeeperPRODBEntities DB = new KeeperPRODBEntities();

            var emailInput = "keeper@mail.ru";
            


            Assert.IsTrue();
        }


    }
}