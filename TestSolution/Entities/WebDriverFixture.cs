using OpenQA.Selenium;

namespace Entities
{

    public sealed class WebDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; }

        public WebDriverFixture()
        {
            Driver = BrowserFactory.CreateDriver(BrowserType.Chrome);
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}

