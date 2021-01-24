    //this will not wait for page to load
    //both properties need to be true in order for element to be clickable
    Assert.True(Driver.FindElement(By elementLocator).Enabled)
    Assert.True(Driver.FindElement(By elementLocator).Displayed)
    //this will search for the element until a timeout is reached
    public static IWebElement WaitUntilElementClickable(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
