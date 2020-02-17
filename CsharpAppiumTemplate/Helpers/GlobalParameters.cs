using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAppiumTemplate.Helpers
{
    class GlobalParameters
    {
        //public static string token;
        //public static string pathProject;
        //public static string url;
        //public static string reportName;
        //public static string dbserver;
        //public static string dbName;
        //public static string dbUserId;
        //public static string dbPassword;
        //public static string dbTimeout;
        //public static int reportSubstringLength;
        //public static string authenticatorUser;
        //public static string authenticatorPassword;


        //public void Initializer()
        //{

        //    if (Properties.Settings.Default.ENVIRONMENT == "qa" || Properties.Settings.Default.ENVIRONMENT == "QA")
        //    {
        //        url = Properties.Settings.Default.QA_URL;
        //        token = Properties.Settings.Default.QA_TOKEN;
        //        dbserver = Properties.Settings.Default.QA_DB_SERVER;
        //        dbName = Properties.Settings.Default.QA_DB_NAME;
        //        dbUserId = Properties.Settings.Default.QA_DB_USER;
        //        dbPassword = Properties.Settings.Default.QA_DB_PASSWORD;
        //        authenticatorUser = Properties.Settings.Default.QA_AUTHENTICATOR_USER;
        //        authenticatorPassword = Properties.Settings.Default.QA_AUTHENTICATOR_PASSWORD;
        //    }
        //    else
        //    {
        //        url = Properties.Settings.Default.DEV_URL;
        //        token = Properties.Settings.Default.DEV_TOKEN;
        //        dbserver = Properties.Settings.Default.DEV_DB_SERVER;
        //        dbName = Properties.Settings.Default.DEV_DB_NAME;
        //        dbUserId = Properties.Settings.Default.DEV_DB_USER;
        //        dbPassword = Properties.Settings.Default.DEV_DB_PASSWORD;
        //        authenticatorUser = Properties.Settings.Default.QA_AUTHENTICATOR_USER;
        //        authenticatorPassword = Properties.Settings.Default.QA_AUTHENTICATOR_PASSWORD;
        //    }

        //    pathProject = GeneralHelpers.ReturnProjectPath();
        //    reportSubstringLength = Properties.Settings.Default.REPORT_SUBSTRING_LENGTH;
        //    dbTimeout = Properties.Settings.Default.DB_CONNECTION_TIMEOUT;
        //    reportName = Properties.Settings.Default.REPORT_NAME + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");

        //}

        public static string BROWSER_DEFAULT;
        public static string EXECUTION;
        public static int TIMEOUT_DEFAULT;
        public static string REPORT_NAME;
        public static bool GET_SCREENSHOT_FOR_EACH_STEP;
        public static string DOWNLOAD_DEFAULT_PATH;
        public static string REPORT_PATH;
        public static string pathProject;
        public static string reportName;

        //---Appium config
        public static string AppiumAutomationName;
        public static string AppiumIPAddress;
        public static string AppiumPort;
        public static string AppiumVersion;
        public static string AppiumServerName;

        //---Android config
        public static string AndroidDeviceName;
        public static string AndroidUDID;
        public static string AndroidPlatformName;
        public static string AndroidPlatformVersion;
        public static string AndroidAppPackage;
        public static string AndroidAppActivity;
        public static string AppiumServer;
        public static string AndroidAppPath;
        public static string AndroidBrowserName;
        public static bool AndroidNoReset;
        public static bool AndroidFullReset;
        public static string AndroidOrientation;

        //---iOS config
        public static string IOSUDID;
        public static string IOSPlatformName;
        public static string IOSPlatformVersion;
        public static string IOSReportFormat;
        public static string IOSTestName;
        public static bool IOSNoReset;
        public static bool IOSFullReset;
        public static string IOSSendKeyStrategy;
        public static string IOSAutomationName;
        public static string IOSDeviceName;
        public static string IOSAppPath;
        public static string IOSBundleId;
        //public static string IOSBundleId;

        //---DeviceFarm config
        public static string TestObjectApiKey;
        public static string TestObjectURL;

        //private Properties properties;

        public GlobalParameters()
        {
            pathProject = GeneralHelpers.ReturnProjectPath();
            reportName = Properties.Settings.Default.CONFIG_REPORT_NAME + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");

            if (Properties.Settings.Default.CONFIG_ENVIRONMENT == "qa" || Properties.Settings.Default.CONFIG_ENVIRONMENT == "QA")
            {
                // url = Properties.Settings.Default.QA_URL;
                GET_SCREENSHOT_FOR_EACH_STEP = Properties.Settings.Default.CONFIG_GET_SCREENSHOT_FOR_EACH_STEP;
                REPORT_NAME = Properties.Settings.Default.CONFIG_REPORT_NAME;
                TIMEOUT_DEFAULT = Properties.Settings.Default.CONFIG_TIMEOUT_DEFAULT;
                EXECUTION = Properties.Settings.Default.CONFIG_ENVIRONMENT;

                AppiumIPAddress = Properties.Settings.Default.APPIUM_IP_ADDRESS;
                AppiumPort = Properties.Settings.Default.APPIUM_PORT;
                AppiumServerName = Properties.Settings.Default.APPIUM_SERVER;
                AppiumAutomationName = Properties.Settings.Default.APPIUM_AUTOMATION_NAME;
                AppiumVersion = Properties.Settings.Default.APPIUM_VERSION;

                AndroidPlatformName = Properties.Settings.Default.ANDROID_PLATAFORM_NAME;
                AndroidPlatformVersion = Properties.Settings.Default.ANDROID_PLATAFORM_VERSION;
                AndroidDeviceName = Properties.Settings.Default.ANDROID_DEVICE_NAME;
                AndroidAppPath = pathProject + "Resources/App/Android/" + Properties.Settings.Default.ANDROID_APP;
                AndroidBrowserName = "";//Properties.Settings.Default.ANDROID_BROWSER_NAME;
                AndroidUDID = Properties.Settings.Default.ANDROID_UDID;
                AndroidNoReset = Properties.Settings.Default.ANDROID_NO_RESET;
                AndroidFullReset = Properties.Settings.Default.ANDROID_FULL_RESET;
                AndroidAppActivity = Properties.Settings.Default.ANDROID_APP_ACTIVITY;
                AndroidAppPackage = Properties.Settings.Default.ANDROID_APP_PACKAGE;
                AndroidOrientation = Properties.Settings.Default.ANDROID_ORIENTATION;

                TestObjectApiKey = Properties.Settings.Default.TEST_OBJECT_API_KEY;
                TestObjectURL = Properties.Settings.Default.TEST_OBJECT_URL;

                IOSUDID = Properties.Settings.Default.IOS_UDID;
                IOSPlatformName = Properties.Settings.Default.IOS_PLATFORM_NAME;
                IOSPlatformVersion = Properties.Settings.Default.IOS_PLATFORM_VERSION;
                IOSBundleId = Properties.Settings.Default.IOS_BUNDLE_ID;
                IOSNoReset = Properties.Settings.Default.IOS_NO_RESET;
                IOSFullReset = Properties.Settings.Default.IOS_FULL_RESET;
                IOSAutomationName = Properties.Settings.Default.IOS_AUTOMATION_NAME;
                IOSDeviceName = Properties.Settings.Default.IOS_DEVICE_NAME;
                IOSAppPath = pathProject + "Resources/App/iOS/" + Properties.Settings.Default.IOS_APP;
            }
            else
            {
                //url = Properties.Settings.Default.DEV_URL;

            }

            

        }


    }
}
