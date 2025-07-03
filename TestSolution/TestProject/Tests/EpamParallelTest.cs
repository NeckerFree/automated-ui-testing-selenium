using Entities.Drivers;
using OpenQA.Selenium;
using TestProject.PageObjects;

namespace TestProject.Tests
{
    [Collection("WebDriverCollection")]
    public sealed class EpamParallelTest : IClassFixture<WebDriverFixture>, IDisposable
    {
        private const string URL = "https://www.saucedemo.com";
        private readonly IWebDriver driver;
        private readonly WebDriverFixture fixture;

        public EpamParallelTest(WebDriverFixture fixture)
        {
            this.fixture = fixture;
            driver = this.fixture.Driver;

            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Test initialized on thread {Thread.CurrentThread.ManagedThreadId}");
            driver.Navigate().GoToUrl(URL);
        }

        public void Dispose()
        {
            if (driver.Url != URL)
            {
                driver.Navigate().GoToUrl(URL);
            }
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Test completed on thread {Thread.CurrentThread.ManagedThreadId}");
        }

        [Fact]
        public void Login_EmptyCredentials_UserRequired()
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Running Login_EmptyCredentials_UserRequired");
            var loginPage = new LoginPage(driver);
            var message = loginPage.LoginInvalidCredentials(string.Empty, string.Empty);
            Assert.Equal("Username is required", message);
        }

        [Theory]
        [InlineData("standard_user")]
        [InlineData("locked_out_user")]
        [InlineData("problem_user")]
        [InlineData("performance_glitch_user")]
        [InlineData("error_user")]
        [InlineData("visual_user")]
        public void Login_CredentialsWithUsername_PasswordRequired(string username)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Running Login_CredentialsWithUsername_PasswordRequired with username: {username}");
            var loginPage = new LoginPage(driver);
            var message = loginPage.LoginInvalidCredentials(username, string.Empty);
            Assert.Equal("Password is required", message);
        }

        [Theory]
        [InlineData("standard_user", "secret_sauce")]
        [InlineData("problem_user", "secret_sauce")]
        [InlineData("performance_glitch_user", "secret_sauce")]
        [InlineData("error_user", "secret_sauce")]
        [InlineData("visual_user", "secret_sauce")]
        public void Login_CredentialsWithUsernameAndPassword_SuccessfulLogin(string username, string password)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Running Login_CredentialsWithUsernameAndPassword_SuccessfulLogin with username: {username}");
            var loginPage = new LoginPage(driver);
            HomePage homePage = loginPage.LoginAs(username, password);
            var tittle = homePage.GetMessage();
            Assert.Equal("Swag Labs", tittle);
        }
    }

    [CollectionDefinition("WebDriverCollection", DisableParallelization = false)]
    public class WebDriverCollection : ICollectionFixture<WebDriverFixture> { }
}

