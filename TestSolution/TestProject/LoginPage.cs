using OpenQA.Selenium;
using System.Xml.Linq;

namespace TestProject
{
    internal class LoginPage
    {
        private readonly IWebDriver driver;
        private static By UsernameLocator => By.CssSelector("input[data-test='username']");
        private static By passwordLocator => By.CssSelector("input[data-test='password']");
        private static By LoginButtonLocator => By.CssSelector("input[data-test='login-button']");
        private static By ErrorMessage => By.CssSelector("h3[data-test='error']");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        internal HomePage LoginAs(string username, string password)
        {
            SendUserName(username);
            SendPassword(password);
            LoginClick();
            return new HomePage(driver);
        }

        internal string LoginInvalidCredentials(string username, string password)
        {
            SendUserName(username);
            SendPassword(password);
            LoginClick();
            return GetErrorMessage();
        }

        private string GetErrorMessage()
        {
            var element = driver.FindElement(ErrorMessage);
            return (element != null) ? element.Text.Replace("Epic sadface: ", string.Empty) : string.Empty;
        }

        private void SendUserName(string username)
        {
            var element = driver.FindElement(UsernameLocator);
            element.Clear();
            element.SendKeys(username);
        }

        private void SendPassword(string password)
        {
            var element = driver.FindElement(passwordLocator);
            element.Clear();
            element.SendKeys(password);
        }

        private void LoginClick()
        {
            driver.FindElement(LoginButtonLocator).Click();
        }




    }
}