    public static Func<IWebDriver, IWebElement> Condition(By locator)
    {
    	return (driver) => {
    		var element = driver.FindElements(locator).FirstOrDefault();
    		return element != null && element.Displayed && element.Enabled ? element : null;
    	};
    }
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
    var elementU = wait.Until(Condition(By.Name("j_username")));
    elementU.Click();
