using CsharpAppiumTemplate.Bases;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects;
using OpenQA.Selenium.Support.PageObjects;


namespace CsharpAppiumTemplate.Pages
{
    public class StartPage : PageBase
    {
        //   [AndroidFindBy](accessibility = "ReferenceApp")
        //private MobileElement menu(accessibility = "ReferenceApp");

        //    public void clickMenu()
        //    {
        //        click(menu);
        //    }

        [FindsByAndroidUIAutomator(Accessibility = "ReferenceApp", Priority = 1)]
        IWebElement menu;

        public void clickMenu()
        {
        Click(menu);
        }
    }
}
