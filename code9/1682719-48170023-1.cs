    public static void WaitAndClick(this IWebDriver driver, IWebElement webelement)
    {
        WebDriverWait fluentWait = new WebDriverWait(driver,Configuration.WaitTime.TotalSeconds);
        //No need to set PollingInterval, default is already 500ms
        fluentWait.IgnoreExceptionTypes(typeof(TargetInvocationException),typeof(NoSuchElementException),typeof(InvalidOperationException));
        fluentWait.Until(ExpectedConditions.ElementToBeClickable(webelement));
        webelement.Click();
    }
