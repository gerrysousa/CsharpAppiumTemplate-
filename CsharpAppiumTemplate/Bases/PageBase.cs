using CsharpAppiumTemplate.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAppiumTemplate.Bases
{
    class PageBase
    {
        //Variaveis globlais
        protected AppiumDriver<AppiumWebElement> driver = null;
        protected WebDriverWait wait = null;
        protected IJavaScriptExecutor javaScriptExecutor = null;

        //Construtor
        public PageBase()
        {
            wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(Convert.ToDouble(Properties.Settings.Default.CONFIG_TIMEOUT_DEFAULT)));
           // driver = DriverFactory.INSTANCE;
            javaScriptExecutor = (IJavaScriptExecutor)driver;
        }

        protected void WaitForElement(By element)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        protected void WaitForElementToBeClickeable(By element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        protected void WaitForElementByTime(By element, int time)
        {
            WebDriverWait waitTime = new WebDriverWait(driver,TimeSpan.FromSeconds(time));
            waitTime.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
        }

        protected void Click(By element)
        {
            WebDriverException possibleWebDriverException = null;
            Stopwatch timeOut = new Stopwatch();
            timeOut.Start();
            while (Convert.ToInt32(timeOut) <= GlobalParameters.TIMEOUT_DEFAULT)
            {
               // AppiumWebElement element = null;
                try
                {
                    //WaitForElement(element);
                    //element.Click();
                    //ExtentReportHelpers.AddTestInfo(3, "");
                    //timeOut.Stop();
                    //return;

                    IWebElement iElement = driver.FindElement(element);
                    WaitForElement(element);
                    TouchActions action = new TouchActions(driver);
                    action.SingleTap(iElement);
                    action.Perform();
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
        protected void SendKeys(By element, string text)
        {
            IWebElement iElement = driver.FindElement(element);
            WaitForElement(element);
            Clear(element);
            iElement.SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }
        protected void SendKeysWithoutWaitVisible(By element, string text)
        {
            IWebElement iElement = driver.FindElement(element);
            iElement.SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }
        protected void Clear(By element)
        {
            //waitForElement(element);
            //element.clear();
            IWebElement iElement = driver.FindElement(element);
            WaitForElement(element);
            iElement.Clear();
        }
        protected void clearAndSendKeys(By element, string text)
        {
            //waitForElement(element);
            //element.clear();
            //element.sendKeys(text);
            IWebElement iElement = driver.FindElement(element);
            WaitForElement(element);
            iElement.Clear();
        }
        protected void ClearAndSendKeysAlternative(By locator, string text)
        {
            IWebElement iElement = driver.FindElement(locator);
            WaitForElement(locator);
            iElement.SendKeys(Keys.Control + "a");
            iElement.SendKeys(Keys.Delete);
            iElement.SendKeys(text);
        }
        protected string GetText(By locator)
        {
            WaitForElement(locator);
            IWebElement iElement = driver.FindElement(locator);
            string text = iElement.Text;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }
        protected string GetValue(By locator)
        {
            WaitForElement(locator);
            IWebElement iElement = driver.FindElement(locator);
            string text = iElement.GetAttribute("value");
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }
        protected bool ReturnIfElementIsDisplayed(By locator)
        {
            WaitForElement(locator);
            IWebElement iElement = driver.FindElement(locator);
            bool result = iElement.Displayed;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }
        protected bool ReturnIfElementIsEnabled(By locator)
        {
            WaitForElement(locator);
            IWebElement iElement = driver.FindElement(locator);
            bool result = iElement.Enabled;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }
        protected bool ReturnIfElementIsSelected(By locator)
        {
            WaitForElement(locator);
            IWebElement iElement = driver.FindElement(locator);
            bool result = iElement.Selected;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }
        protected void ZZZZScrollUsingTouchActions_ByElements(By startElement, By endElement, int seconds)
        {
            //TouchAction actions = new TouchAction(driver);
            //actions.Press(PointOption.point(startElement.getLocation().x, startElement.getLocation().y))
            //        .waitAction(WaitOptions.waitOptions(Duration.ofSeconds(seconds)))
            //        .moveTo(PointOption.point(endElement.getLocation().x, endElement.getLocation().y)).release().perform();
            
        }
        protected void scrollUsingTouchActions(int startX, int startY, int endX, int endY, int seconds)
        {
            TouchAction actions = new TouchAction(driver);
            actions.Press(startX, startY).Wait(seconds).MoveTo(endX, endY).Release().Perform();
        }
        protected void longPress(By locator)
        {
            WaitForElement(locator);
            IWebElement iElement = driver.FindElement(locator);
            
            TouchActions action = new TouchActions(driver);
            action.LongPress(iElement);
            action.Perform();
        }
        protected void scrolling(string direction)
        {
            //JavascriptExecutor js = (JavascriptExecutor)driver;
            //HashMap<string, string> scrollObject = new HashMap<string, string>();
            //scrollObject.put("direction", direction);
            //js.executeScript("mobile: scroll", scrollObject);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Dictionary<string, string> scrollObject = new Dictionary<string, string>();
            scrollObject.Add("direction", direction);
            js.ExecuteScript("mobile: scroll", scrollObject);
        }
        protected void tap(By locator)
        {
            //waitForElement(element);
            //TouchActions action = new TouchActions(driver);
            //action.singleTap(element);
            //action.perform();
            WaitForElement(locator);
            IWebElement iElement = driver.FindElement(locator);
            TouchActions action = new TouchActions(driver);
            action.SingleTap(iElement);
            action.Perform();
        }
        protected void doubleTap(By locator)
        {
            WaitForElement(locator);
            IWebElement iElement = driver.FindElement(locator);
            TouchActions action = new TouchActions(driver);
            action.DoubleTap(iElement);
            action.Perform();
        }

        //Função para realizar scroll somente em Android
        //protected By scrollToElementAndroid(string sdfstring)
        //{
        //    return ((AndroidDriver<By>)driver).findElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0)).scrollIntoView(new UiSelector().textContains(\"" + string + "\").instance(0))");
        //}
    }
}
