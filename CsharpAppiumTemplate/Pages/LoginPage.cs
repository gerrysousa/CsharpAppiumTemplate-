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
        //    @iOSFindBy(accessibility= "Username Input Field")
        //@AndroidFindBy(accessibility= "Username Input Field")
        //private MobileElement usernameField;
        //    @iOSFindBy(accessibility = "Password Input Field")
        //@AndroidFindBy(accessibility = "Password Input Field")
        //private MobileElement passwordField;
        //    @iOSFindBy(accessibility = "Login Button")
        //@AndroidFindBy(accessibility = "Login Button")
        //private MobileElement loginBtn;
        //    @iOSFindBy(accessibility = "Alt Message")
        //@AndroidFindBy(accessibility = "Alt Message")
        //private MobileElement message;

        //    public void usernameFill(String username)
        //    {
        //        sendKeys(usernameField, username);
        //    }
        //    public void passwordFill(String password)
        //    {
        //        sendKeys(passwordField, password);
        //    }
        //    public void clickLoginBtn()
        //    {
        //        click(loginBtn);
        //    }
        //    public String getMessageText()
        //    {
        //        return message.getText();
        //    }

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


    }
}
