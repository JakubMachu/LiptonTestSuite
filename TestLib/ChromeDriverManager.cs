using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestLib
{
    public class ChromeDriverManager
    {
        private IWebDriver driver;

        public ChromeDriverManager(string chromeDriverPath)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            driver = new ChromeDriver(chromeDriverPath, options);
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
    }
}
