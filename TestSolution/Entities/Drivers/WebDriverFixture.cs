using OpenQA.Selenium;

namespace Entities.Drivers
{

    public sealed class WebDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; }

        public WebDriverFixture()
        {
            Driver = BrowserFactory.CreateDriver(BrowserType.Firefox);
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}

