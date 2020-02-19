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
    class InputControlsPage : PageBase
    {
        #region mapeamento
        [FindsByAndroidUIAutomator(XPath ="//android.widget.TextView[@text='Text Field']", Priority = 1)]
        IWebElement pageTextField;

    //    @iOSFindBy(xpath= "//XCUIElementTypeTextView")
    //@AndroidFindBy(xpath= "//android.widget.TextView[@text='Text Field']")
    //private MobileElement pageTextField;

        #endregion

        #region açoes
        public void clickMenu()
        {
            ScrollRightAndroid();
            ScrollLeftAndroid();
            ScrollUpAndroid();
            ScrollDownAndroid();

            Click(pageTextField);
        }

        #endregion
    }
}
