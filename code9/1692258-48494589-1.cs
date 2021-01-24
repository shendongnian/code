    String cssSelector = "div[ng-click*='selectButtonClick']";
    
    IList elements = driver.FindElements(By.CssSelector(cssSelector)).ToList();
    
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    int numberOfElements=elements.Count(); 
    
    for (int i = 0; i < numberOfElements; i++)
    {
        // click checkbox
        elements.ElementAt(i).Click();
        // click button
        driver.FindElement(
            By.CssSelector("button[ng-click*='checkoutSelectedApplication']")).Click();
        // wait page refresh/load complete  
        wait.Until(ExpectedConditions
                 .ElementToBeClickable(By.CssSelector(cssSelector)));
        // find all checkbox again, because page changed,
        // otherwise report StaleReference
        elements = driver.FindElements(By.CssSelector(cssSelector));
    }
