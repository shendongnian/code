        public void SetDropdownValue(IWebElement dropdown, string value)
        {
            By valueXpath = By.XPath("//div[@id='select2-drop']//li[div[text()='" + value + "']]");
            dropdown.FindElement(By.XPath(".//b[@role='presentation']")).Click();
            new WebDriverWait(Driver, TimeSpan.FromSeconds(1)).Until(ExpectedConditions.ElementExists(valueXpath));
            Driver.FindElement(valueXpath).Click();
        }
