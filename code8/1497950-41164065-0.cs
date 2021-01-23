    IWebElement moto = driver.FindElement(By.Id("Moto"));
    Actions actions = new Actions(driver);
    actions.MoveToElement(moto).Perform();
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Moto"))).Click();
