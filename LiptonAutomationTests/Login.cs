using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestLib;

namespace SauceDemoTests
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            ChromeDriverManager driverManager = new ChromeDriverManager(Constants.ChromePath);
            driver = driverManager.GetDriver();
        }

        [TestMethod]
        public void LoginWithValidCredentials()
        {

            driver.Navigate().GoToUrl(Constants.HomePage);

            IWebElement usernameInput = driver.FindElement(By.Id("user-name"));
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("login-button"));

            usernameInput.SendKeys("standard_user");
            passwordInput.SendKeys("secret_sauce");
            loginButton.Click();

            IWebElement productsHeader = driver.FindElement(By.ClassName("product_label"));
            Assert.IsTrue(productsHeader.Displayed, "Login failed.");
        }

        [TestMethod]
        public void LoginWithInvalidCredentials()
        {

            driver.Navigate().GoToUrl(Constants.HomePage);

            IWebElement usernameInput = driver.FindElement(By.Id("user-name"));
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("login-button"));

            usernameInput.SendKeys("invalid_user");
            passwordInput.SendKeys("invalid_password");
            loginButton.Click();

            IWebElement errorElement = driver.FindElement(By.CssSelector("h3[data-test='error']"));
            Assert.IsTrue(errorElement.Displayed, "Expected error message not displayed.");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}

