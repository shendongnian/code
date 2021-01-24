    bool ElementExists(By locator)
    {
        TimeSpan originalWait = driver.Manage().Timeouts().ImplicitWait;
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        bool exists = driver.FindElements(locator).Count > 0;
        driver.Manage().Timeouts().ImplicitWait = originalWait;
        return exists;
    }
    if(ElementExists(By.Id("your locator")))
    {
        //Do Stuff
    }
    else
    {
        //Do Stuff when element does not exist
    }
