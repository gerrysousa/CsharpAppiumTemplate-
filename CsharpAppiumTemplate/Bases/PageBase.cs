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
                try
                {
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
            WaitForElement(element);
            Clear(element);
            element.SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }
        protected void SendKeysWithoutWaitVisible(IWebElement element, string text)
        {
            element.SendKeys(text);
            ExtentReportHelpers.AddTestInfo(3, "PARAMETER: " + text);
        }
        protected void Clear(IWebElement element)
        {
            WaitForElement(element);
            element.Clear();
        }
        protected void clearAndSendKeys(IWebElement element, string text)
        {
            WaitForElement(element);
            element.Clear();
        }
        protected void ClearAndSendKeysAlternative(IWebElement element, string text)
        {
            WaitForElement(element);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.SendKeys(text);
        }
        protected string GetText(IWebElement element)
        {
            WaitForElement(element);
            string text = element.Text;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }
        protected string GetValue(IWebElement element)
        {
            WaitForElement(element);
            string text = element.GetAttribute("value");
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + text);
            return text;
        }
        protected bool ReturnIfElementIsDisplayed(IWebElement element)
        {
            WaitForElement(element);
            bool result = element.Displayed;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }
        protected bool ReturnIfElementIsEnabled(IWebElement element)
        {
            WaitForElement(element);
            bool result = element.Enabled;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }
        protected bool ReturnIfElementIsSelected(IWebElement element)
        {
            WaitForElement(element);
            bool result = element.Selected;
            ExtentReportHelpers.AddTestInfo(3, "RETURN: " + result);
            return result;
        }

        protected void ZZZZScrollUsingTouchActions(string direcao)
        {
            TouchAction action = new TouchAction(DriverFactory.GetDriver());
            action.Press(100,300);
            action.MoveTo(300,300);
            action.Perform();
            action.Release();
            ExtentReportHelpers.AddTestInfo(3, "");

            // driver.ExecuteScript("mobile:scroll", new Dictionary<string, string> { { "direction", "left" } });         
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

        public void ScrollUsingTouchActions(int xStart, int yStart, int xFinal, int yFinal)
        {
            TouchAction action = new TouchAction(DriverFactory.GetDriver());
            action.Press(xStart, yStart);
            action.MoveTo(xFinal, yFinal);
            action.Wait(100);
            action.Perform();
            action.Release();
            ExtentReportHelpers.AddTestInfo(3, "");
        }

        public void ScrollDownAndroid()
        {
            ScrollUsingTouchActions(525, 1900, 525, 300);
        }

        public void ScrollUpAndroid()
        {
            ScrollUsingTouchActions(525, 600, 525, 1900);
        }

        public void ScrollLeftAndroid()
        {
            ScrollUsingTouchActions(90, 1100, 999, 1100);
        }

        public void ScrollRightAndroid()
        {
            int width = DriverFactory.GetDriver().Manage().Window.Size.Width;
            int height = DriverFactory.GetDriver().Manage().Window.Size.Height;

            //int xInicial = width-50;
            //int yInicial = (height / 2);

            //int xFinal = 10;
            //int yFinal = height / 2;
            int xInicial = 999;
            int yInicial = 1100;

            int xFinal = 90;
            int yFinal = 1100;

            ScrollUsingTouchActions(xInicial, yInicial, xFinal, yFinal);
            // ScrollUsingTouchActions(350, 450, 70, 450);
        }
    }
}
