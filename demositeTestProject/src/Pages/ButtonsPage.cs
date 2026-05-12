using System;
using OpenQA.Selenium;
using demositeTestProject.src.Constants;

namespace demositeTestProject.src.Pages;

public class ButtonsPage : BasePage
{
    private By DoubleClickButton = By.Id("doubleClickBtn");
    private By RightClickButton = By.CssSelector("button#rightClickBtn[type='button']");
    private By ClickMeButton = By.XPath("//button[@type = 'button' and text() = 'Click Me']");
    private By DoubleClickMessage = By.CssSelector("p#doubleClickMessage");
    private By RightClickMessage = By.CssSelector("p#rightClickMessage");
    private By ClickMeMessage = By.CssSelector("p#dynamicClickMessage");

    public ButtonsPage(IWebDriver driver) : base(driver)
    {
    }

    public void ClickDoubleClickButton()
    {
        DoubleClick(DoubleClickButton);
    }

    public void ClickRightClickButton()
    {
        RightClick(RightClickButton);
    }

    public void ClickClickMeButton()
    {
        Click(ClickMeButton);
    }

    public string GetDoubleClickMessage()
    {
        return GetText(DoubleClickMessage);
    }

    public string GetRightClickMessage()
    {
        return GetText(RightClickMessage);
    }

    public string GetClickMeMessage()
    {
        return GetText(ClickMeMessage);
    }

    public bool IsDoubleClickMessageDisplayed()
    {
        return IsDisplayed(DoubleClickMessage);
    }

    public bool IsRightClickMessageDisplayed()
    {
        return IsDisplayed(RightClickMessage);
    }

    public bool IsClickMeMessageDisplayed()
    {
        return IsDisplayed(ClickMeMessage);
    }
}