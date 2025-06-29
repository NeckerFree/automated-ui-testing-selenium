# Selenium WebDriver Testing Project

## Overview

This project provides a framework for browser automation testing using Selenium WebDriver. It includes a factory pattern for creating browser instances and a fixture for managing the WebDriver lifecycle.

## Project Structure

### Key Components

1. **BrowserFactory.cs**
   - Static factory class for creating WebDriver instances
   - Supports Chrome and Firefox browsers
   - Uses the BrowserType enum to determine which browser to instantiate

2. **BrowserType.cs**
   - Enum defining supported browser types (Chrome, Firefox)

3. **WebDriverFixture.cs**
   - Implements IDisposable for proper resource cleanup
   - Creates and manages the WebDriver instance lifecycle
   - Automatically quits and disposes the driver when the fixture is disposed

4. **Entities.csproj**
   - Project configuration file
   - Targets .NET 9.0
   - Includes necessary Selenium WebDriver packages

## Usage

### Creating a WebDriver Instance

```csharp
// Create a Chrome driver
var chromeDriver = BrowserFactory.CreateDriver(BrowserType.Chrome);

// Create a Firefox driver
var firefoxDriver = BrowserFactory.CreateDriver(BrowserType.Firefox);
```

### Using the WebDriverFixture

```csharp
using (var fixture = new WebDriverFixture())
{
    var driver = fixture.Driver;
    // Your test code here
    driver.Navigate().GoToUrl("https://example.com");
    // The driver will be automatically disposed when the using block ends
}
```

## Dependencies

- Selenium.WebDriver (v4.33.0)
- Selenium.WebDriver.ChromeDriver (v138.0.7204.4900)
- Selenium.WebDriver.GeckoDriver (v0.36.0)


## Setup Instructions

1. Ensure you have .NET 9.0 SDK installed
2. Restore NuGet packages
3. Make sure you have the appropriate browser versions installed that match the driver versions
4. For Chrome/Firefox, ensure the browsers are installed in their default locations

## Contribution

Feel free to extend this project by:
- Adding support for more browsers (Edge, Safari, etc.)
- Implementing additional WebDriver configuration options
- Adding helper methods for common testing operations