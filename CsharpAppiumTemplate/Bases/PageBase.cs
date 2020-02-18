using CsharpAppiumTemplate.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using OpenQA.Selenium.Appium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Appium.PageObjects;

namespace CsharpAppiumTemplate.Bases
{
   public class PageBase
    {
        //Variaveis globlais
        public AppiumDriver<AppiumWebElement> driver;// = null;
        public WebDriverWait wait = null;
        protected IJavaScriptExecutor javaScriptExecutor = null;

        //Construtor
        public PageBase()
        {
            driver = DriverFactory.GetDriver();
            AppiumPageObjectMemberDecorator decorator = new AppiumPageObjectMemberDecorator(new TimeOutDuration(System.TimeSpan.FromSeconds(15)));
            PageFactory.InitElements(driver, this, decorator);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalParameters.TIMEOUT_DEFAULT));
            // driver = DriverFactory.INSTANCE;
            javaScriptExecutor = (IJavaScriptExecutor)driver;
        }

        protected void WaitForElement(IWebElement element)
        {
            //wait.Until(ExpectedConditions.ElementIsVisible(element));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        protected void WaitForElementToBeClickeable(IWebElement element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        protected void WaitForElementByTime(IWebElement element, int time)
        {
            WebDriverWait waitTime = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(time));
            //waitTime.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
        }

        protected void Click(IWebElement element)
        {
            WebDriverException possibleWebDriverException = null;
            Stopwatch timeOut = new Stopwatch();
            timeOut.Start();

            while ((((int)timeOut.ElapsedMilliseconds) / 1000) <= GlobalParameters.TIMEOUT_DEFAULT)
            {
               // AppiumWebElement element = null;
                try
                {
                    // //WaitForElement(element);
                    // //element.Click();
                    // //ExtentReportHelpers.AddTestInfo(3, "");
                    // //timeOut.Stop();
                    // //return;

                    //// //IWebElement iElement = driver.FindElement(element);
                    //// WaitForElement(element);
                    // TouchActions action = new TouchActions(DriverFactory.GetDriver());
                    // action.SingleTap(element);
                    // action.Perform();
                    // ExtentReportHelpers.AddTestInfo(3, "");
                    // timeOut.Stop();
                    // return;

                    TouchAction action= new TouchAction(DriverFactory.GetDriver());
                    action.Tap(element);
                   // action.SingleTap(element);
                    action.Perform();
                    action.Release();
                    ExtentReportHelpers.AddTestInfo(3, "");
                    timeOut.Stop();
                    return;




                }
                catch (StaleElementReferenceException e)
                {
                    continue;
                }
                catch (WebDriverException e)
                {
                    possibleWebDriverException = e;
                    if (e.Message.Contains("Other element would receive the click"))
                    {
                        continue;
                    }
                    throw e;
                }
            }
            try
            {
                throw new Exception(possibleWebDriverException.Message);
            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
            }
        }
        protected void SendKeys(IWebElement element, string text)
        {
            ////IWebElement iElement = driver.FindElement(element);
            WaitForElement(element);
            Clear(element);
            element.SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }
        protected void SendKeysWithoutWaitVisible(IWebElement element, string text)
        {
            //IWebElement iElement = driver.FindElement(element);
            element.SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }
        protected void Clear(IWebElement element)
        {
            //waitForElement(element);
            //element.clear();
            ////IWebElement iElement = driver.FindElement(element);
            WaitForElement(element);
            element.Clear();
        }
        protected void clearAndSendKeys(IWebElement element, string text)
        {
            //waitForElement(element);
            //element.clear();
            //element.sendKeys(text);
            //IWebElement iElement = driver.FindElement(element);
            WaitForElement(element);
            element.Clear();
        }
        protected void ClearAndSendKeysAlternative(IWebElement element, string text)
        {
            //IWebElement iElement = driver.FindElement(element);
            WaitForElement(element);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.SendKeys(text);
        }
        protected string GetText(IWebElement element)
        {
            WaitForElement(element);
            //IWebElement iElement = driver.FindElement(element);
            string text = element.Text;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }
        protected string GetValue(IWebElement element)
        {
            WaitForElement(element);
            //IWebElement iElement = driver.FindElement(element);
            string text = element.GetAttribute("value");
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }
        protected bool ReturnIfElementIsDisplayed(IWebElement element)
        {
            WaitForElement(element);
            //IWebElement iElement = driver.FindElement(element);
            bool result = element.Displayed;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }
        protected bool ReturnIfElementIsEnabled(IWebElement element)
        {
            WaitForElement(element);
            //IWebElement iElement = driver.FindElement(element);
            bool result = element.Enabled;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }
        protected bool ReturnIfElementIsSelected(IWebElement element)
        {
            WaitForElement(element);
            //IWebElement iElement = driver.FindElement(element);
            bool result = element.Selected;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }
        protected void ZZZZScrollUsingTouchActions_ByElements(IWebElement startElement, IWebElement endElement, int seconds)
        {
            //TouchAction actions = new TouchAction(driver);
            //actions.Press(PointOption.point(startElement.getLocation().x, startElement.getLocation().y))
            //        .waitAction(WaitOptions.waitOptions(Duration.ofSeconds(seconds)))
            //        .moveTo(PointOption.point(endElement.getLocation().x, endElement.getLocation().y)).release().perform();
            
        }
        protected void scrollUsingTouchActions(int startX, int startY, int endX, int endY, int seconds)
        {
            TouchAction actions = new TouchAction(DriverFactory.GetDriver());
            actions.Press(startX, startY).Wait(seconds).MoveTo(endX, endY).Release().Perform();
        }
        protected void longPress(IWebElement element)
        {
            WaitForElement(element);
            //IWebElement iElement = driver.FindElement(element);
            
            TouchActions action = new TouchActions(DriverFactory.GetDriver());
            action.LongPress(element);
            action.Perform();
        }
        protected void scrolling(string direction)
        {
            //JavascriptExecutor js = (JavascriptExecutor)driver;
            //HashMap<string, string> scrollObject = new HashMap<string, string>();
            //scrollObject.put("direction", direction);
            //js.executeScript("mobile: scroll", scrollObject);
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverFactory.GetDriver();
            Dictionary<string, string> scrollObject = new Dictionary<string, string>();
            scrollObject.Add("direction", direction);
            js.ExecuteScript("mobile: scroll", scrollObject);
        }
        protected void Tap(IWebElement element)
        {
            //waitForElement(element);
            //TouchActions action = new TouchActions(driver);
            //action.singleTap(element);
            //action.perform();
            WaitForElement(element);
            //IWebElement iElement = driver.FindElement(element);
            TouchActions action = new TouchActions(DriverFactory.GetDriver());
            action.SingleTap(element);
            action.Perform();
        }
        protected void doubleTap(IWebElement element)
        {
            WaitForElement(element);
            //IWebElement iElement = driver.FindElement(element);
            TouchActions action = new TouchActions(DriverFactory.GetDriver());
            action.DoubleTap(element);
            action.Perform();
        }

        //Função para realizar scroll somente em Android
        //protected By scrollToElementAndroid(string sdfstring)
        //{
        //    return ((AndroidDriver<By>)driver).findElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + string + "\").instance(0))");
        //}
    }
}
