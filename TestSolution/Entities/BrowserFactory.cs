using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Entities
{
    public static class BrowserFactory
    {
        public static IWebDriver CreateDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return CreateChromeDriver();
                case BrowserType.Firefox:
                    return CreateFirefoxDriver();
                default:
                   throw new ArgumentOutOfRangeException(nameof(browserType), browserType,null);
            }
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            return new ChromeDriver(new ChromeOptions());
        }

        private static IWebDriver CreateChromeDriver()
        {
            return new FirefoxDriver(new FirefoxOptions());
        }
    }
}
