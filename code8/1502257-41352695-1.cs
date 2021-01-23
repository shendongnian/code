    public IWebElement FindElement(IWebDriver driver, By howBy)
    {
        TimeSpan elementTimeOut = TimeSpan.FromSeconds(20);
        IWebElement elementfound = null;
        try
        {
            WebDriverWait wait = new WebDriverWait(driver, elementTimeOut);
            elementFound = wait.Until<IWebElement>(d => driver.FindElement(howBy));
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Please fail WebDriverTimeoutException");
        } 
        return elementfound;
    }
