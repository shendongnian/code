    WebDriverWait wait1 = new WebDriverWait(driver, new TimeSpan(0,0,60));
    wait1.until(ExpectedConditions.InvisibilityOfElementLocated(By.xpath("xpath of loading symbol"));
    wait1.Until(ExpectedConditions.ElementSelectionStateToBe(By.XPath(GPDNav),true));
    // wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath(GPDNav)));
    IWebElement gpdNav = driver.FindElement(By.XPath(GPDNav));
    gpdNav.Click();
