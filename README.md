🚀 Selenium Automated Login Tests
This project contains automated Selenium tests for verifying login behavior on SauceDemo using C#, xUnit, and WebDriver. The tests cover key use cases like missing credentials and successful login scenarios.

📂 Project Overview
Tests Included

EpamParallelTest.cs
Runs tests in parallel using xUnit’s collection fixtures with shared WebDriver instances.

EpamSerialTest.cs
Runs tests serially with independent WebDriver instances.

Page Objects

LoginPage.cs – Handles all login interactions.

HomePage.cs – Validates successful login by checking the dashboard title.

✅ Test Cases
Test Case	Description
Login_EmptyCredentials_UserRequired	Submits empty username and password; expects “Username is required”.
Login_CredentialsWithUsername_PasswordRequired	Submits a username only; expects “Password is required”.
Login_CredentialsWithUsernameAndPassword_SuccessfulLogin	Submits valid username and password; expects successful login.

🛠️ How to Run the Tests
Install Dependencies

Make sure you have:

.NET SDK installed (tested with .NET 6+).

A supported browser driver (e.g., ChromeDriver or GeckoDriver) on your PATH.

Restore NuGet packages:

dotnet restore
Build the Project


dotnet build
Run Tests

For serial tests:


dotnet test --filter FullyQualifiedName~EpamSerialTest
For parallel tests:


dotnet test --filter FullyQualifiedName~EpamParallelTest
View Results

xUnit test results will display directly in your terminal.

🔑 Process to Follow When Writing or Updating Tests
Identify the Use Case

Define what behavior you need to test: e.g., login with missing username.

Create/Update Test Methods

Place your tests in either EpamSerialTest or EpamParallelTest depending on whether they should run in sequence or concurrently.

Use [Fact] for single tests or [Theory] with [InlineData] for parameterized tests.

Use Page Objects

Use LoginPage methods like LoginAs() or LoginInvalidCredentials() to interact with the UI.

Validate results via assertions on HomePage or error messages.

Keep Test Isolation

Each test should start from the SauceDemo login page.

Dispose() method ensures cleanup by quitting WebDriver sessions.

Run Tests Locally


⚙️ Notes on Parallel vs. Serial Execution
EpamParallelTest
Uses xUnit’s IClassFixture with WebDriverFixture and a collection definition to enable parallel execution of tests sharing the same WebDriver instance.

EpamSerialTest
Creates a fresh WebDriver instance for each test, ensuring full isolation but slower execution.

Selenium WebDriver for .NET

SauceDemo – demo app used for testing.