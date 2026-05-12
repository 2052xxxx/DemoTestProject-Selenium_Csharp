using System;
using OpenQA.Selenium;
using demositeTestProject.src.Constants;

namespace demositeTestProject.src.Pages;

public class SelectMenuPage : BasePage
{
private By SelectMenu = By.Id("withOptGroup");
private By OptionItem = By.XPath("//div[@role = 'option' and text() = 'Group 2, option 1']");

    public SelectMenuPage(IWebDriver driver) : base(driver)
    {
    }

    public void SelectOption()
    {
        Click(SelectMenu);
        Click(OptionItem);
    }
}
