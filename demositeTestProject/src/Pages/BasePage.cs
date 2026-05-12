namespace demositeTestProject.src.Pages;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;

public class BasePage
{
    protected IWebDriver driver;
    protected WebDriverWait wait;
    protected int timeoutSeconds = 10;

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
    }
    // public void WaitForPageLoad()
    // {
    //     wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
    // }

    public void NavigateTo(string url)
    {
        driver.Navigate().GoToUrl(url);
        WaitForPageLoad();
    }
    public void WaitForPageLoad()
    {
        wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

        var imageLocator = By.CssSelector("header img");
        wait.Until(d =>
        {
            try
            {
                var element = d.FindElement(imageLocator);
                return (bool)((IJavaScriptExecutor)d).ExecuteScript(
                    "return arguments[0].complete && typeof arguments[0].naturalWidth != 'undefined' && arguments[0].naturalWidth > 0",
                    element);
            }
            catch (NoSuchElementException) { return false; }
            catch (StaleElementReferenceException) { return false; }
        });
    }
    protected void WaitForElement(By locator)
    {
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
    }

    protected void WaitForClickable(By locator)
    {
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
    }


    protected bool IsElementInViewport(IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        return (bool)js.ExecuteScript(
            "return (function() {" +
            "  var rect = arguments[0].getBoundingClientRect();" +
            "  return (" +
            "    rect.top >= 0 && " +
            "    rect.left >= 0 && " +
            "    rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) && " +
            "    rect.right <= (window.innerWidth || document.documentElement.clientWidth)" +
            "  );" +
            "})(arguments[0]);",
            element
        );
    }

    protected void ScrollToElement(IWebElement element)
    {
        new Actions(driver)
            .ScrollToElement(element)
            .Perform();
    }
    protected void Click(By locator)
    {
        WaitForElement(locator);
        WaitForClickable(locator);
        IWebElement element = driver.FindElement(locator);

        // Check if element is in viewport
        while (!IsElementInViewport(element))
        {
            // Scroll to element if not visible
            ScrollToElement(element);
        }

        element.Click();
    }


    protected void DoubleClick(By locator)
    {
        WaitForElement(locator);
        WaitForClickable(locator);

        IWebElement element = driver.FindElement(locator);
        // ScrollToElement(element);
        Actions actions = new Actions(driver);

        actions.DoubleClick(element).Perform();
    }

    protected void RightClick(By locator)
    {
        WaitForElement(locator);
        WaitForClickable(locator);

        IWebElement element = driver.FindElement(locator);
        // ScrollToElement(element);
        Actions actions = new Actions(driver);

        actions.ContextClick(element).Perform();
    }

    protected void EnterText(By locator, string text)
    {
        WaitForElement(locator);
        var element = driver.FindElement(locator);
        element.Clear();
        element.SendKeys(text);
    }
    protected string GetText(By locator)
    {
        WaitForElement(locator);
        return driver.FindElement(locator).Text;
    }

    protected bool IsDisplayed(By locator)
    {
        try
        {
            WaitForElement(locator);
            return driver.FindElement(locator).Displayed;
        }
        catch
        {
            return false;
        }
    }
}