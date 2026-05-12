# NUnit Selenium Test Automation Framework

A comprehensive, enterprise-grade test automation framework built with NUnit, Selenium WebDriver, and the Page Object Model pattern.

## Project Structure

```
NUnitSeleniumTests/
├── src/
│   ├── Tests/           # Test classes organized by category
│   ├── Pages/           # Page Object Model classes
│   ├── Utilities/       # Helper classes, drivers, constants
│   ├── TestData/        # Test data and fixtures
│   └── Extensions/      # Extension methods
├── Configuration/       # Config files for different environments
├── Tests/              # Test output (screenshots, logs, reports)
└── runsettings.xml    # Visual Studio test settings
```

## Setup Instructions

### Prerequisites
- .NET 6.0 or later
- Visual Studio 2022 or VS Code
- Chrome, Firefox, or Edge browser

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd NUnitSeleniumTests
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Build the project**
   ```bash
   dotnet build
   ```

### Configuration

1. Update `appsettings.json` with your application URL:
   ```json
   {
     "ApplicationUrl": "https://your-app-url.com",
     "BrowserType": "Chrome",
     "Headless": false
   }
   ```

2. Configure test users in `AppConfig.cs`

## Running Tests

### Run all tests
```bash
dotnet test
```

### Run specific test class
```bash
dotnet test --filter "ClassName=LoginTests"
```

### Run tests by category
```bash
dotnet test --filter "Category=Smoke"
```

### Run with specific browser
Modify `BrowserType` in your test setup or configuration file.

### Generate HTML Report
```bash
dotnet test -- --logger:"trx;LogFileName=TestResults.trx"
```

## Framework Features

### Page Object Model
- Base page class with common operations
- Encapsulation of page elements and actions
- Reusable methods for element interaction

### Test Organization
- Organized by test type (UI, API, Integration)
- Categorized with Tags (Smoke, Regression)
- Data-driven tests with TestCase attributes

### Utilities
- **DriverFactory**: Centralized WebDriver instantiation
- **WaitHelper**: Explicit waits for element visibility
- **ScreenshotHelper**: Automatic screenshots on failure
- **LogHelper**: Comprehensive logging
- **Constants**: Centralized configuration

### Best Practices
- Clear test naming: `Test<Feature><Scenario>`
- Arrange-Act-Assert (AAA) pattern
- No hardcoded values - use constants
- DRY principle - reuse page objects
- Proper setup and teardown
- Meaningful assertions with descriptive messages

## Writing Tests

### Example Test Structure
```csharp
[TestFixture]
public class LoginTests
{
    private IWebDriver driver;
    private LoginPage loginPage;

    [SetUp]
    public void Setup()
    {
        driver = DriverFactory.CreateDriver();
        loginPage = new LoginPage(driver);
    }

    [TearDown]
    public void TearDown()
    {
        DriverFactory.QuitDriver(driver);
    }

    [Test]
    [Category("Smoke")]
    public void TestValidLogin()
    {
        loginPage.Login("user@test.com", "password");
        Assert.IsTrue(loginPage.IsLoggedIn());
    }
}
```

## Test Reporting

Test results are generated in the `Tests/Reports/` directory:
- TRX (Visual Studio Test Results)
- HTML reports (if using reporting tool)
- Screenshots of failures in `Tests/Screenshots/`

## Logging

Logs are saved to `Tests/Logs/` directory using NLog:
- Info: General test flow information
- Error: Test failures and exceptions
- Debug: Detailed diagnostic information

## Dependencies

- **NUnit**: Testing framework
- **Selenium WebDriver**: Browser automation
- **WebDriverManager**: Automatic driver management
- **NLog**: Logging framework
- **RestSharp**: API testing
- **Newtonsoft.Json**: JSON handling

## Troubleshooting

### WebDriver not found
- Ensure WebDriverManager is properly installed
- Clear NuGet cache: `dotnet nuget locals all --clear`

### Tests timeout
- Increase wait times in `Timeouts` class
- Check element locators in page objects
- Verify application is running

### Screenshots not saving
- Verify `Tests/Screenshots/` directory exists
- Check file write permissions

## Contributing

1. Follow the existing code structure
2. Use meaningful variable and method names
3. Add tests for new features
4. Update documentation
5. Run full test suite before committing

---

# Automation Testing Demostration
## Setup Selenium C# in VS Code How - To
### 1. Create a Test Project

Open your terminal in VS Code and run the following commands to create a new NUnit test project (a common framework for Selenium tests):


```
# Create a folder & move into it
mkdir MySeleniumTests && cd MySeleniumTests

# Create a new NUnit project
dotnet new nunit
```

### 2. Install Selenium Packages

Add the required [Selenium.WebDriver](https://www.nuget.org/packages/Selenium.WebDriver) and browser driver packages using the .NET CLI:
```
# Core Selenium package
dotnet add package Selenium.WebDriver

# Browser-specific driver (e.g., Chrome)
dotnet add package Selenium.WebDriver.ChromeDriver
```

### 3. Write Your First Test

Replace the code in your UnitTest1.cs file with a basic script to open a browser:
```
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MySeleniumTests;

public class Tests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        // Initializes the Chrome driver
        driver = new ChromeDriver();
    }

    [Test]
    public void OpenGoogleTest()
    {
        driver.Navigate().GoToUrl("https://google.com");
        Assert.That(driver.Title, Is.Not.Empty);
    }

    [TearDown]
    public void Dispose()
    {
        driver.Quit();
    }
}
```

## Inspect Dynamic Dropdown 
1. Open DevTools UI
2. Press Ctrl + Shift + P
3. Enter "emulate a focus"
4. Choose Emulate a focused page

*Source:* [StackOverFlow - Inspecting drop down menus in new Chrome](https://stackoverflow.com/questions/29386116/inspecting-drop-down-menus-in-new-chrome)
