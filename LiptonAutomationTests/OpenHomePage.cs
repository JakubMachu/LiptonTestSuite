using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestLib;

namespace LiptonAutomationTests
{
    [TestClass]
    public class OpenHomePage
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            ChromeDriverManager driverManager = new ChromeDriverManager(Constants.ChromePath);
            driver = driverManager.GetDriver();
        }

        [TestMethod]
        public void ValidatePageToBeLoaded()
        {
            driver.Navigate().GoToUrl(Constants.LiptonHomePage);

            string pageTitle = driver.Title;
            if (pageTitle.Contains("Lipton"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false, "Page title does not contain 'Lipton' - page load failed!");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}

