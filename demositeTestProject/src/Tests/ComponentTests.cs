namespace demositeTestProject;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using demositeTestProject.src.Pages;

public class ComponentTests
{
    private IWebDriver driver;
    private HomePage homePage;
    private ButtonsPage buttonsPage;
    private RadioButtonPage radioButtonPage;
    private SelectMenuPage selectMenuPage;
    private FormPage formPage;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        homePage = new HomePage(driver);
        buttonsPage = new ButtonsPage(driver);
        radioButtonPage = new RadioButtonPage(driver);
        selectMenuPage = new SelectMenuPage(driver);
        formPage = new FormPage(driver);
    }

    [Test]
    public void OpenDemoQATest()
    {
        homePage.NavigateTo("https://demoqa.com/");
        Assert.That(homePage.GetPageTitle(), Is.Not.Empty);
    }

    // [Test]
    // [Category("Buttons")]
    // public void DoubleClickButtonTest()
    // {
    //     homePage.NavigateTo("https://demoqa.com/buttons");
    //     Thread.Sleep(1000);
    //     buttonsPage.ClickDoubleClickButton();

    //     Assert.That(buttonsPage.IsDoubleClickMessageDisplayed(), Is.True);
    //     Assert.That(buttonsPage.GetDoubleClickMessage(), Is.Not.Empty);
    // }

    // [Test]
    // [Category("Buttons")]
    // public void RightClickButtonTest()
    // {
    //     homePage.NavigateTo("https://demoqa.com/buttons");
    //     Thread.Sleep(1000);
    //     buttonsPage.ClickRightClickButton();

    //     Assert.That(buttonsPage.IsRightClickMessageDisplayed(), Is.True);
    //     Assert.That(buttonsPage.GetRightClickMessage(), Is.Not.Empty);
    // }

    [Test]
    [Category("Buttons")]
    public void ClickButtonTest()
    {
        buttonsPage.NavigateTo("https://demoqa.com/buttons");
        buttonsPage.ClickClickMeButton();

        Assert.That(buttonsPage.IsClickMeMessageDisplayed(), Is.True);
        Assert.That(buttonsPage.GetClickMeMessage(), Is.Not.Empty);

        buttonsPage.ClickDoubleClickButton();

        Assert.That(buttonsPage.IsDoubleClickMessageDisplayed(), Is.True);
        Assert.That(buttonsPage.GetDoubleClickMessage(), Is.Not.Empty);

        buttonsPage.ClickRightClickButton();

        Assert.That(buttonsPage.IsRightClickMessageDisplayed(), Is.True);
        Assert.That(buttonsPage.GetRightClickMessage(), Is.Not.Empty);
    }

    [Test]
    public void ClickRadioButtonTest()
    {
        homePage.NavigateTo("https://demoqa.com/radio-button");
        radioButtonPage.ClickYesRadioButton();
        radioButtonPage.ClickImpressiveRadioButton();
    }

    [Test]
    public void ClickSelectMenuTest()
    {
        homePage.NavigateTo("https://demoqa.com/select-menu");
        selectMenuPage.SelectOption();
    }

    [Test]
    public void FormSubmitTest()
    {
        homePage.NavigateTo("https://demoqa.com/automation-practice-form");
        formPage.FillForm("MyTestData@example.com", "Van A", "Nguyen", "0123456789", "M");
    }

    [TearDown]
    public void Teardown()
    {
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}