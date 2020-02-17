using CsharpAppiumTemplate.Bases;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAppiumTemplate.Pages
{
    class StartPage : PageBase
    {
        //   [AndroidFindBy](accessibility = "ReferenceApp")
        //private MobileElement menu(accessibility = "ReferenceApp");

        //    public void clickMenu()
        //    {
        //        click(menu);
        //    }

        [FindsByAndroidUIAutomator(XPath = "(//android.widget.TextView[@content-desc=\"Row Category Name\"])[8]", Priority = 1)]
        private By menu;

        public void clickMenu()
        {
            Click(menu);
        }
    }
}
