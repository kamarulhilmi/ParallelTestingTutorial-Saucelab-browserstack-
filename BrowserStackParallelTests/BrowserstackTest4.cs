using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace BrowserStackParallelTests
{
    [TestFixture]
    [Parallelizable]
    public class BrowserstackTest4
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            DesiredCapabilities capability = DesiredCapabilities.Firefox();
            capability.SetCapability("browserstack.user", "nikolayadvolodki1");
            capability.SetCapability("browserstack.key", "ux6rpccX5ku7W7tRmsiZ");
            capability.SetCapability("browser", "Safari");
            capability.SetCapability("browser_version", "5.1");
            capability.SetCapability("os", "OS X");
            capability.SetCapability("os_version", "Snow Leopard");
            capability.SetCapability("resolution", "1024x768");

            driver = new RemoteWebDriver(
                new Uri("http://hub.browserstack.com/wd/hub/"), capability
                );
        }

        [Test]
        public void BrowserStackTest4()
        {
            driver.Navigate().GoToUrl("http://www.qtptutorial.net/automation-practice");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("idExample")).Click();
            var elementCheck = driver.FindElement(By.XPath("//p[contains(text(),'Button success')]")).Displayed;
            Assert.IsTrue(elementCheck, "Element was not present");
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}