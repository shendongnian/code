    String xpath = "//div[@ng-click='selectButtonClick(row, $event)']";
    
    IList elements = driver.FindElements(By.XPath(xpath)).ToList();
    
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    int numberOfElements=elements.Count(); 
    
    for (int i = 0; i < numberOfElements; i++)
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(elements.ElementAt(i)));
        elements.ElementAt(i).Click();
        elements = driver.FindElements(By.XPath(xpath));
    }
