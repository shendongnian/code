    public IWebElement FindElement(IWebDriver driver, By howBy)
    {
        TimeSpan elementTimeOut = TimeSpan.FromSeconds(20);
        IWebElement elementfound = null;
        try
        {
            WebDriverWait wait = new WebDriverWait(driver, elementTimeOut);
            elementFound = wait.Until<IWebElement>(d =>
            {
                try
                {
                    elementfound = driver.FindElement(howBy);
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine("Please fail NoSuchElementException");
                }
                return elementfound;
            });
        }
        catch (WebDriverTimeoutException)
        {
            Console.WriteLine("Please fail WebDriverTimeoutException");
        }
        return elementfound;
    }
