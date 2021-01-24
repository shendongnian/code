        public static void Click(By locator)
        {
            _driver.FindElement(locator).Click();
        }
    Your `VariableList` class would look like
        public static class VariableList
        {
            public static By LoginButtonId = By.Id("whateverTheIdIs");
        }
    and you would call it like
        _driver.Click(VariableList.LoginButtonId)
