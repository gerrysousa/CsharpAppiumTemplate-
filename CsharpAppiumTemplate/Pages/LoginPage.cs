using CsharpAppiumTemplate.Bases;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Support.PageObjects;

namespace CsharpAppiumTemplate.Pages
{
    public class LoginPage : PageBase
    {
        #region mapeamento
        [FindsByIOSUIAutomation(Accessibility = "Username Input Field", Priority = 1)]
        [FindsByAndroidUIAutomator(Accessibility = "Username Input Field", Priority = 1)]
        IWebElement usernameField;
        
        [FindsByIOSUIAutomation(Accessibility = "Password Input Field", Priority = 1)]
        [FindsByAndroidUIAutomator(Accessibility = "Password Input Field", Priority = 1)]
        IWebElement passwordField;


        [FindsByIOSUIAutomation(Accessibility = "Login Button", Priority = 1)]
        [FindsByAndroidUIAutomator(Accessibility = "Login Button", Priority = 1)]
        IWebElement loginBtn;

        [FindsByIOSUIAutomation(Accessibility = "Alt Message", Priority = 1)]
        [FindsByAndroidUIAutomator(Accessibility = "Alt Message", Priority = 1)]
        IWebElement message;

        #endregion

        #region Acoes da pagina
        public void usernameFill(String username)
        {
            SendKeys(usernameField, username);
        }
        public void passwordFill(String password)
        {
            SendKeys(passwordField, password);
        }
        public void clickLoginBtn()
        {
            Click(loginBtn);
        }
        public string getMessageText()
        {
           string texto = GetText(message);
            return texto;
        }

        #endregion

    }
}
