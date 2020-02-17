using CsharpAppiumTemplate.Bases;
using CsharpAppiumTemplate.Flows;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAppiumTemplate.Tests
{
    class LoginTests : TestBase
    {
        LoginFlows loginFlow;

        [Test]//(priority = 1, description = "teste de login valido")
        public void loginTest()
        {
            string username = "admin";
            string password = "password";

            loginFlow = new LoginFlows();
            loginFlow.GoToLoginPage();
            string message = loginFlow.Login(username, password);

            Assert.AreEqual("You are logged on as admin", message);
        }

        [Test]//(priority = 1, description = "teste de login invalido")
        public void loginInvalidTest()
        {
            string username = "teste123";
            string password = "teste123";

            loginFlow = new LoginFlows();
            loginFlow.GoToLoginPage();
            string message = loginFlow.Login(username, password);

            Assert.AreEqual("You gave me the wrong username and password", message);
        }
    }
}
