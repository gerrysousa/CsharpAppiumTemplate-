using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAppiumTemplate.Helpers
{
    class DriverFactory
    {
        public static AppiumDriver<AppiumWebElement> driver;
        public static AppiumLocalService appiumLocalService;
        public WebDriverWait wait;

        public static IWebDriver INSTANCE { get; set; } = null;
        //public static ITakesScreenshot INSTANCE { get; internal set; }

        public static AppiumDriver<AppiumWebElement> GetDriver()
        {
            if (driver == null)
            {
                throw new NullReferenceException("The Driver instance was not initialized.");
            }                
            return driver;
        }

        //public void setDriver(AppiumDriver<AppiumWebElement> driver)
        //{
        //    driver = driver;
        //}

        public static AppiumDriver<AppiumWebElement> InitApp(string deviceType= "Android", string environment ="local")
        {
            try
            {
                appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
                appiumLocalService.Start();

                if (environment.Equals("local"))
                {
                    if (deviceType.Equals("Android"))
                    {
                        //DesiredCapabilities caps = new DesiredCapabilities();
                        //caps.SetCapability("platformName", GlobalParameters.AndroidPlatformName);
                        //caps.SetCapability("platformVersion", GlobalParameters.AndroidPlatformVersion);
                        //caps.SetCapability("deviceName", GlobalParameters.AndroidDeviceName);
                        //caps.SetCapability("app", GlobalParameters.AndroidAppPath);
                        //caps.SetCapability("browserName", GlobalParameters.AndroidBrowserName);
                        //caps.SetCapability("udid", GlobalParameters.AndroidUDID);
                        //caps.SetCapability("noReset", GlobalParameters.AndroidNoReset);
                        //caps.SetCapability("fullReset", GlobalParameters.AndroidFullReset);
                        //caps.SetCapability("orientation", GlobalParameters.AndroidOrientation);
                        //caps.SetCapability("automationName", GlobalParameters.AppiumAutomationName);
                        //driver = new AndroidDriver<AppiumWebElement>(new Uri("GlobalParameters.AppiumServer"), caps);

                        var appiumOptions = new AppiumOptions();
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, GlobalParameters.AndroidAppPath);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, GlobalParameters.AndroidDeviceName);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, GlobalParameters.AndroidPlatformName);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, GlobalParameters.AndroidUDID);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, GlobalParameters.AndroidPlatformVersion);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, GlobalParameters.AndroidBrowserName);

                        //driver = new AndroidDriver<AppiumWebElement>(appiumLocalService, appiumOptions);
                        driver = new AndroidDriver<AppiumWebElement>(new Uri(GlobalParameters.AppiumServerName), appiumOptions);
                    }
                    else if (deviceType.Equals("IOS"))
                    {
                    //    DesiredCapabilities caps = new DesiredCapabilities();
                    //    caps.SetCapability("platformName", GlobalParameters.IOSPlatformName);
                    //    caps.SetCapability("platformVersion", GlobalParameters.IOSPlatformVersion);
                    //    caps.SetCapability("deviceName", GlobalParameters.IOSDeviceName);
                    //    caps.SetCapability("automationName", GlobalParameters.IOSAutomationName);
                    //    //caps.setCapability("bundleId", GlobalParameters.IOSBundleId);
                    //    caps.SetCapability("app", GlobalParameters.IOSAppPath);
                    //    //caps.setCapability("udid", GlobalParameters.IOSUDID);
                    //    //caps.setCapability(CapabilityType.BROWSER_NAME, "safari");
                    //    //    caps.setCapability("noReset", GlobalParameters.IOSNoReset);
                    //    //    caps.setCapability("fullReset", GlobalParameters.IOSFullReset);

                    //    //driver = new IOSDriver(new URL("http://0.0.0.0:4723/wd/hub"), caps);
                    //    driver = new IOSDriver<AppiumWebElement>(new Uri("GlobalParameters.AppiumServer"), caps);
                    }
                }
                else
                { // Essa parte cria a instancia em uma Device Farm
                    if (deviceType.Equals("Android"))
                    {
                        //DesiredCapabilities caps = new DesiredCapabilities();
                        //caps.SetCapability("platformName", GlobalParameters.AndroidPlatformName);
                        //caps.SetCapability("automationName", GlobalParameters.AppiumAutomationName);
                        //caps.SetCapability("testobject_api_key", GlobalParameters.TestObjectApiKey);
                        //caps.SetCapability("appiumVersion", GlobalParameters.AppiumVersion);

                        //driver = new AndroidDriver(new URL(GlobalParameters.TestObjectURL), caps);
                    }
                    else if (deviceType == "IOS")
                    {

                    }
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();//System.out.print("Vish! Nao conseguiu criar o driver!!!");
            }
            return driver;
        }

        public static void killDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }

        public static void QuitInstace()
        {
            INSTANCE.Quit();
            //INSTANCE.Close();
            INSTANCE.Dispose();
            INSTANCE = null;
        }
    }
}
