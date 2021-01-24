        // Click Checkbox
        public void ClickCheckbox(IWebElement element)
        {
            WaitUntilClickable(element, 10);
            element.Click();
            // element.SendKeys(Space);
            // element.SendKeys(Enter); 
            Console.WriteLine( element + " Clicked");
        }
        // Wait Until Clickable
        public static void WaitUntilClickable(IWebElement elementLocator, int timeout)
        {
            try
            {
                WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                waitForElement.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element: '"+element+"' was not found in current context page.");
                throw;
            }
        }
