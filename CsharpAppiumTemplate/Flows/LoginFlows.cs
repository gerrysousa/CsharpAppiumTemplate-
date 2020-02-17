using CsharpAppiumTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAppiumTemplate.Flows
{
    class LoginFlows
    {
        private LoginPage loginPage;
        private StartPage startPage;
        private MenuPage menuPage;

        public LoginFlows()
        {
            startPage = new StartPage();
            menuPage = new MenuPage();
            loginPage = new LoginPage();
        }
        public void GoToLoginPage()
        {
            startPage.clickMenu();
            menuPage.clickLoginPage();
        }
        public string Login(String username, String password)
        {
            loginPage.usernameFill(username);
            loginPage.passwordFill(password);
            loginPage.clickLoginBtn();
            return loginPage.getMessageText();
        }
    }
}
