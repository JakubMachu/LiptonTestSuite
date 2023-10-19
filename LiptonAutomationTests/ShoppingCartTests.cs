using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestLib;

namespace SauceDemoTests
{
    [TestClass]
    public class ShoppingCartTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            ChromeDriverManager driverManager = new ChromeDriverManager(Constants.ChromePath);
            driver = driverManager.GetDriver();
        }

        [TestMethod]
        public void AddProductToCartAndCheckout()
        {

            driver.Navigate().GoToUrl(Constants.HomePage);

            IWebElement usernameInput = driver.FindElement(By.Id("user-name"));
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("login-button"));

            usernameInput.SendKeys("standard_user");
            passwordInput.SendKeys("secret_sauce");
            loginButton.Click();

            IWebElement addToCartButton = driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addToCartButton.Click();

            IWebElement cartIcon = driver.FindElement(By.Id("shopping_cart_container"));
            cartIcon.Click();

            IWebElement checkoutButton = driver.FindElement(By.Id("checkout"));
            checkoutButton.Click();

            IWebElement firstNameInput = driver.FindElement(By.Id("first-name"));
            IWebElement lastNameInput = driver.FindElement(By.Id("last-name"));
            IWebElement zipCodeInput = driver.FindElement(By.Id("postal-code"));
            IWebElement continueButton = driver.FindElement(By.CssSelector(".cart_button"));

            firstNameInput.SendKeys("John");
            lastNameInput.SendKeys("Doe");
            zipCodeInput.SendKeys("12345");
            continueButton.Click();

            IWebElement finishButton = driver.FindElement(By.CssSelector(".cart_button"));
            Assert.IsTrue(finishButton.Displayed, "Checkout failed.");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
