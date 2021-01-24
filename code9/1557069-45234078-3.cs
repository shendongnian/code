    public static void ClickAndWaitForPageToLoad(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                var element = Driver.FindElement(elementLocator);
                element.Click();
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
