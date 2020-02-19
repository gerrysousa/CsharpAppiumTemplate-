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

        //public void SetDriver(AppiumDriver<AppiumWebElement> driver)
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
                        var appiumOptions = new AppiumOptions();
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, GlobalParameters.AndroidAppPath);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, GlobalParameters.AndroidDeviceName);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, GlobalParameters.AndroidPlatformName);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, GlobalParameters.AndroidUDID);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, GlobalParameters.AndroidPlatformVersion);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, GlobalParameters.AndroidBrowserName);

                        //Opcionais
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, GlobalParameters.AndroidNoReset);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset, GlobalParameters.AndroidFullReset);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.Orientation, GlobalParameters.AndroidOrientation);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalParameters.AppiumAutomationName);

                        driver = new AndroidDriver<AppiumWebElement>(new Uri(GlobalParameters.AppiumServerName), appiumOptions);
                    }
                    else if (deviceType.Equals("IOS"))
                    {
                        var appiumOptions = new AppiumOptions();
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, GlobalParameters.IOSPlatformName);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, GlobalParameters.IOSPlatformVersion);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, GlobalParameters.IOSDeviceName);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalParameters.IOSAutomationName);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, GlobalParameters.IOSAppPath);
                        //appiumOptions.AddAdditionalCapability(MobileCapabilityType.bundleId", GlobalParameters.IOSBundleId);
                        //appiumOptions.AddAdditionalCapability(MobileCapabilityType.Udid, GlobalParameters.IOSUDID);
                        //appiumOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, GlobalParameters.IosBrowserName);
                        //appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset", GlobalParameters.IOSNoReset);
                        //appiumOptions.AddAdditionalCapability(MobileCapabilityType.FullReset", GlobalParameters.IOSFullReset);

                        driver = new AndroidDriver<AppiumWebElement>(new Uri(GlobalParameters.AppiumServerName), appiumOptions);
                    }
                }
                else
                { // Essa parte cria a instancia em uma Device Farm
                    if (deviceType.Equals("Android"))
                    {
                        var appiumOptions = new AppiumOptions();
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, GlobalParameters.AndroidPlatformName);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, GlobalParameters.AppiumAutomationName);
                        appiumOptions.AddAdditionalCapability("testobject_api_key", GlobalParameters.TestObjectApiKey);
                        appiumOptions.AddAdditionalCapability(MobileCapabilityType.AppiumVersion, GlobalParameters.AppiumVersion);

                        driver = new AndroidDriver<AppiumWebElement>(new Uri(GlobalParameters.TestObjectURL), appiumOptions);                        
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

        public static void KillDriver()
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
