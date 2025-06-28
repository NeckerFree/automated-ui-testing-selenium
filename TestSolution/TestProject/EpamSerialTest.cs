using Entities;
using OpenQA.Selenium;
namespace TestProject
{

    public sealed class EpamSerialTest : IDisposable
    {
        private readonly IWebDriver driver;

        public EpamSerialTest()
        {
            driver = BrowserFactory.CreateDriver(BrowserType.Firefox);
            driver.Navigate().GoToUrl("https://www.saucedemo.com");

        }

        public void Dispose()
        {
            driver.Dispose();
        }

        /// <summary>
        /// UC-1 Test Login form with empty credentials
        /// </summary>
        [Fact]
        public void Login_EmptyCredentials_UserRequired()
        {
            var loginPage = new LoginPage(driver);
            var message = loginPage.LoginInvalidCredentials(string.Empty, string.Empty);
            Assert.Equal("Username is required", message);
        }



        /// <summary>
        /// UC-2 Test Login form with credentials by passing Username
        /// </summary>
        [Theory]
        [InlineData("standard_user")]
        [InlineData("locked_out_user")]
        [InlineData("problem_user")]
        [InlineData("performance_glitch_user")]
        [InlineData("error_user")]
        [InlineData("visual_user")]
        public void Login_CredentialsWithUsername_PasswordRequired(string username)
        {
            var loginPage = new LoginPage(driver);
            var message = loginPage.LoginInvalidCredentials(username, string.Empty);
            Assert.Equal("Password is required", message);
        }

        /// <summary>
        /// UC-3 Test Login form with credentials by passing Username & Password
        /// </summary>

        [Theory]
        [InlineData("standard_user")]
        [InlineData("locked_out_user")]
        [InlineData("problem_user")]
        [InlineData("performance_glitch_user")]
        [InlineData("error_user")]
        [InlineData("visual_user")]
        public void Login_CredentialsWithUsernameAndPasswod_PasswordRequired(string username)
        {
            var loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.LoginAs(username, "secret_sauce");
            Assert.Equal("Swag Labs", homePage.GetMessage());
        }



        //private void CaptureScreenshot(string fileName)
        //{
        //    try
        //    {
        //        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        //        screenshot.SaveAsFile($"{fileName}_{DateTime.Now:yyyyMMddHHmmss}.png");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Failed to capture screenshot: {ex.Message}");
        //    }
        //}
    }
}
