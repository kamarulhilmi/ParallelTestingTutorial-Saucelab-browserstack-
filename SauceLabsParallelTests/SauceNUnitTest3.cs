using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SauceLabsParallelTests
{
    [TestFixture("1.6.4", "Samsung Galaxy S3 Emulator", "portrait", "Browser", "4.4", "Android")]
    public class SauceNUnitTest3
    {
        private IWebDriver _driver;

        private string appiumVersion;
        private string deviceName;
        private string deviceOrientation;
        private string browserName;
        private string platformVersion;
        private string platformName;

        public SauceNUnitTest3(string AppiumVersion, string DeviceName, string DeviceOrientation, string BrowserName, string PlatformVersion, string  PlatformName)
        {
            appiumVersion = AppiumVersion;
            deviceName  = DeviceName;
            deviceOrientation = DeviceOrientation;
            browserName = BrowserName;
            platformVersion = PlatformVersion;
            platformName = PlatformName;
        }

        [SetUp]
        public void Init()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("appiumVersion", appiumVersion);
            caps.SetCapability("deviceName", deviceName );
            caps.SetCapability("deviceOrientation", deviceOrientation);
            caps.SetCapability("browserName", browserName);
            caps.SetCapability("platformVersion", platformVersion );
            caps.SetCapability("platformName", platformName);
            caps.SetCapability("username", "kamarulhilmi");
            caps.SetCapability("accessKey", "8bae2123-3ddd-43b4-ae01-47fb4a2cfc60");
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

            _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps,
                TimeSpan.FromSeconds(600));

        }

        [Test]
        public void UltimateQaTestModified()
        {
            _driver.Navigate().GoToUrl("http://courses.ultimateqa.com");
            Assert.IsTrue(true);
        }

        [TearDown]
        public void CleanUp()
        {
            bool passed = true;
            try
            {
                // Logs the result to Sauce Labs
                ((IJavaScriptExecutor)_driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                // Terminates the remote webdriver session
                _driver.Quit();
            }
        }
    }
}