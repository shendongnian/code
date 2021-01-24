        public IWebElement WaitForCondition(IWebDriver driver, Func<IWebDriver, IWebElement> expectedCondition,
            double timeout)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return webDriverWait.Until(expectedCondition);
        }
