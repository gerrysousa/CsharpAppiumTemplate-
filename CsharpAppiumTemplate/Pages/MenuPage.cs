using CsharpAppiumTemplate.Bases;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
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
        #region mapeamento
        [FindsByAndroidUIAutomator(XPath = "(//android.widget.TextView[@content-desc=\"Row Category Name\"])[8]", Priority = 1)]
        IWebElement loginPageBtn;

        [FindsByAndroidUIAutomator(XPath = "//android.widget.TextView[@text='Input Controls']", Priority = 1)]
        IWebElement inputControlsBtn;



        #endregion

        #region acoes na tela
        public void clickLoginPage()
        {
            Click(loginPageBtn);
        }
        public void clickInputControls()
        {
            Click(inputControlsBtn);
        }

        #endregion
    }
}
