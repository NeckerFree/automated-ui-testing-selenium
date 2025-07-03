using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Entities.Drivers
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
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.SetPreference("browser.privatebrowsing.autostart", true);
            return new FirefoxDriver(firefoxOptions);
        }

        private static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--guest");
            return new ChromeDriver(options);

        }
    }
}
