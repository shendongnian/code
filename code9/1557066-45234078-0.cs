    //this will not wait for page to load
    Assert.True(Driver.FindElement(By elementLocator).Enabled)
    //this will search for the element until a timeout is reached
    public static IWebElement WaitUntilElementExists(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
