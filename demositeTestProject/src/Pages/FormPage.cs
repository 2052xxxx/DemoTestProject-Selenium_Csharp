using System;
using OpenQA.Selenium;
using demositeTestProject.src.Constants;

namespace demositeTestProject.src.Pages;

public class FormPage : BasePage
{
    private By EmailField = By.Id("userEmail");
    private By FirstNameField = By.Id("firstName");
    private By LastNameField = By.Id("lastName");
    private By GenderRadio = By.XPath("//input[@type='radio' and @id='gender-radio-2']");
    private By MobileField = By.Id("userNumber");
    private By SubjectsField = By.XPath("//input[@class='subjects-auto-complete__input']");
    private By SubjectMaths = By.XPath("//div[@id='subjectsContainer'] //div[text()='Maths']");
    private By HobbiesReading = By.XPath("//div[@id = 'hobbiesWrapper'] // label[text() = 'Reading'] / preceding-sibling::input[@type = 'checkbox']");
    private By StateField = By.CssSelector("div[class^='css'][class$='container']#state");
    private By CityField = By.CssSelector("div[class^='css'][class$='container']#city");
    private By StateOptionField = By.XPath("//div[contains(@class, 'menu')] //div[text() = 'NCR']");
    private By CityOptionField = By.XPath("//div[contains(@class, 'menu')] //div[text() = 'Delhi']");
    private By SubmitButton = By.CssSelector("button#submit");
    public FormPage(IWebDriver driver) : base(driver)
    {
    }

    public void FillForm(string email, string firstName, string lastName, string mobile, string subjects)
    {
        EnterText(EmailField, email);
        EnterText(FirstNameField, firstName);
        EnterText(LastNameField, lastName);
        Click(GenderRadio);
        EnterText(MobileField, mobile);
        EnterText(SubjectsField, subjects);
        Click(SubjectMaths);
        ScrollToElement(HobbiesReading);
        Click(HobbiesReading);
        ScrollToElement(StateField);
        Click(StateField);
        Click(StateOptionField);
        Click(CityField);
        Click(CityOptionField);
        Click(SubmitButton);
    }
}