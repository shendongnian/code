    wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
    if (!driver.FindElement(By.CssSelector("selector")).Displayed)
    {
        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("selector")));
        driver.FindElement(By.CssSelector("selector")).Text; // There are other properties and methods if you need
    }
