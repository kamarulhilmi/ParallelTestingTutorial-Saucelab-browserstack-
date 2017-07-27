using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Appium_Tests
{
    [TestFixture("1.6.3", "AppiumTest_Custom Phone-6.0.0-API23-768x1280", "portrait", "", "6.0", "Android", "colornote.apk")]
    [TestFixture("1.6.3", "Samsung Galaxy S6-7.10-API25-1440x2560", "portrait", "", "7.1", "Android", "colornote.apk")]
    [TestFixture("", "iPhone Simulator", "", "", "10.2", "iOS", "http://appium.s3.amazonaws.com/TestApp7.1.app.zip")]

    public class Appium_Test_02
    {
        public static RemoteWebDriver driver;

        private string appiumVersion;
        private string deviceName;
        private string deviceOrientation;
        private string browserName;
        private string platformVersion;
        private string platformName;
        private string apps;

        public Appium_Test_02(string AppiumVersion, string DeviceName, string DeviceOrientation, string BrowserName, string PlatformVersion, string PlatformName, string Apps)
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
            caps.SetCapability("username", "panglimaselat"); 
            caps.SetCapability("accessKey", "0353da72-4f34-4cd1-bdbc-7305d465d174"); 
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps,
                TimeSpan.FromSeconds(120));

        }

        [Test]
        public void Appium_Saucelab_test_02()
        {
            driver.FindElementById("OK").Click();
            driver.FindElementById("IntegerA").SendKeys("100");
            driver.FindElementById("IntegerB").SendKeys("200");
            var sum = driver.FindElementById("ComputeSumButton");
            Assert.AreEqual("300", sum);
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