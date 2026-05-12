using System;
using OpenQA.Selenium;
using demositeTestProject.src.Constants;

namespace demositeTestProject.src.Pages;

public class RadioButtonPage : BasePage
{
    private By YesRadioButton = By.CssSelector("#yesRadio");
    private By ImpressiveRadioButton = By.Id("impressiveRadio");
    private By NoRadioButton = By.CssSelector("div.form-check > input#noRadio[type='radio']");

    public RadioButtonPage(IWebDriver driver) : base(driver)
    {
    }

    public void ClickYesRadioButton()
    {
        Click(YesRadioButton);
    }

    public void ClickImpressiveRadioButton()
    {
        Click(ImpressiveRadioButton);
    }

    public void ClickNoRadioButton()
    {
        Click(NoRadioButton);
    }
}