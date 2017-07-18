﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SauceLabsParallelTests
{
    [TestFixture("chrome", "26.0", "Windows XP", "", "")]
    [Parallelizable]
    public class SauceNUnitTest
    {
        private IWebDriver _driver;
        private string _browser;
        private string _version;
        private string _os;
        private string _deviceName;
        private string _deviceOrientation;

        public SauceNUnitTest(string browser, string version, string os, string deviceName, string deviceOrientation)
        {
            _browser = browser;
            _version = version;
            _os = os;
            _deviceName = deviceName;
            _deviceOrientation = deviceOrientation;
        }

        [SetUp]
        public void Init()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, _browser);
            caps.SetCapability(CapabilityType.Version, _version);
            caps.SetCapability(CapabilityType.Platform, _os);
            caps.SetCapability("deviceName", _deviceName);
            caps.SetCapability("deviceOrientation", _deviceOrientation);
            caps.SetCapability("username", "kamarulhilmi");
            caps.SetCapability("accessKey", "8bae2123-3ddd-43b4-ae01-47fb4a2cfc60");
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

            _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps,
                TimeSpan.FromSeconds(600));

        }

        [Test]
        public void UltimateQaTest1()
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