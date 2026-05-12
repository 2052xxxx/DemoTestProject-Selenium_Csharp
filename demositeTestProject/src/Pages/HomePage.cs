using System;
using OpenQA.Selenium;

namespace demositeTestProject.src.Pages;

public class HomePage : BasePage
{
    public HomePage(IWebDriver driver) : base(driver)
    {
    }

    public string GetPageTitle()
    {
        return driver.Title;
    }
}