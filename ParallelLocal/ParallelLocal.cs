using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace ParallelLocal
{
    [Parallelizable]
    public class ParallelLocal
    {
        [Test]
        public void Test1()
        {
            var driver = new ChromeDriver(@"C:\library");
            driver.Navigate().GoToUrl("http://www.qtptutorial.net/automation-practice");
            driver.Manage().Window.Maximize();
            driver.FindElementById("idExample").Click();
            var elementCheck = driver.FindElementByXPath("//p[contains(text(),'Button success')]").Displayed;
            Assert.IsTrue(elementCheck, "Element was not present");
        }
    }
}
