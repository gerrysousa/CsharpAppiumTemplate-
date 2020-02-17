using CsharpAppiumTemplate.Bases;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAppiumTemplate.Pages
{
    class MenuPage : PageBase
    {
        //@AndroidFindBy(xpath = "(//android.widget.TextView[@content-desc=\"Row Category Name\"])[8]")
        //  private MobileElement loginPageBtn;
        //@AndroidFindBy(xpath = "(//android.widget.TextView[@content-desc=\"Row Category Name\"])[4]")
        //private MobileElement inputControlsBtn;

        //public void clickLoginPage()
        //{
        //    click(loginPageBtn);
        //}
        //public void clickInputControls()
        //{
        //    click(inputControlsBtn);
        //}

        //========================================================================================
        //[FindsBySequence]
        //[MobileFindsByAll(Android = true, IOS = true)]
        //[FindsByIOSUIAutomation(nameof = "Email Address", Priority = 1)]
        //[FindsByAndroidUIAutomator(ID = "com.yardi.pshark:id / mat_edit_text_email", Priority = 1)]
        //public IWebElement usernameField;

        [FindsByAndroidUIAutomator(XPath = "(//android.widget.TextView[@content-desc=\"Row Category Name\"])[8]", Priority = 1)]
        private By loginPageBtn;

        [FindsByAndroidUIAutomator(XPath = "(//android.widget.TextView[@content-desc=\"Row Category Name\"])[4]", Priority = 1)]
        private By inputControlsBtn;

        public void clickLoginPage()
        {
            Click(loginPageBtn);
        }
        public void clickInputControls()
        {
            Click(inputControlsBtn);
        }
    }
}
