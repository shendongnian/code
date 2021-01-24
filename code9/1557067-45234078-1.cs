    //this will not wait for page to load
    Assert.True(Driver.FindElement(By elementLocator).Displayed)
    //this will search for the element until a timeout is reached
    public static IWebElement WaitUntilElementVisible(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }
