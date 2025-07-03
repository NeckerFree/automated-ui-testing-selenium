
using OpenQA.Selenium;

namespace TestProject.PageObjects
{
    internal class HomePage
    {
        private readonly IWebDriver driver; 
        private static By DashBoardTitle => By.CssSelector("div.header_label > div.app_logo");
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal string GetMessage()
        {
           var element= driver.FindElement(DashBoardTitle);
            return element.Text;
        }
    }
}