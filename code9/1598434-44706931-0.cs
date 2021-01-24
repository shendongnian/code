      public void SetDropDownValue(string Xpath, string value)
        {
            var element = FindElement(By.Xpath("Xpath"));
            var selectElement = new SelectElement(element);
            //check whether the option is selectable or not
            var wait = new WebDriverWait(this.driver, this.testCaseConfiguration.WaitTime);
            wait.Until(ExpectedConditions.TextToBePresentInElement(selectElement , option));
            try
            {
                selectElement.SelectByText(value);
            }
            catch (StaleElementReferenceException)
            {
                element = FindElement(By.Xpath("Xpath"));
                selectElement = new SelectElement(element);
                selectElement.SelectByText(value);
            }
        }
