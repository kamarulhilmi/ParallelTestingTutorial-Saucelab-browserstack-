using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Tests
{
    [TestFixture("1.6.3", "Samsung Galaxy S6 - 7.10-API25-1440x2560", "portrait", "", "7.1", "Android", "colornote.apk")]

    public class Appium_Test_01
    {
        AndroidDriver<AndroidElement> driver;

        private string appiumVersion;
        private string deviceName;
        private string deviceOrientation;
        private string browserName;
        private string platformVersion;
        private string platformName;
        private string apps;

        public Appium_Test_01(string AppiumVersion, string DeviceName, string DeviceOrientation, string BrowserName, string PlatformVersion, string PlatformName, string Apps)
        {
            appiumVersion = AppiumVersion;
            deviceName = DeviceName;
            deviceOrientation = DeviceOrientation;
            browserName = BrowserName;
            platformVersion = PlatformVersion;
            platformName = PlatformName;
            apps = Apps;
        }

        [SetUp]
        public void Init()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("appiumVersion", appiumVersion);
            caps.SetCapability("deviceName", deviceName);
            caps.SetCapability("deviceOrientation", deviceOrientation);
            caps.SetCapability("browserName", browserName);
            caps.SetCapability("platformVersion", platformVersion);
            caps.SetCapability("platformName", platformName);
            caps.SetCapability("app", apps);
            //caps.SetCapability("username", "kamarulhilmi");
            //caps.SetCapability("accessKey", "8bae2123-3ddd-43b4-ae01-47fb4a2cfc60");
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

            driver = new AndroidDriver<AndroidElement>(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps,
                TimeSpan.FromSeconds(120));

        }

        [Test]
        public void Appium_Saucelab_test_01()
        {
            Assert.IsNotNull(driver.Context);
        }

        [TearDown]
        public void CleanUp()
        {
            bool passed = true;
            try
            {
                // Logs the result to Sauce Labs
                ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                // Terminates the remote webdriver session
                driver.Quit();
            }
        }
    }
}