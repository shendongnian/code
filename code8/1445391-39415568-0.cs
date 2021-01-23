    IWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
    //Now wait for iframe to available and then switch 
     wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("scContentIframeId0"));
    //Now find desire element inside this iframe 
    IWebElement LinkDescription = wait.Until(ExpectedConditions.ElementExists(By.Id("Text")));
    LinkDescription.SendKeys("External Link");
    //Now after performing all stuff inside iframe switch back to default content 
    driver.SwitchTo().DefaultContent(); 
