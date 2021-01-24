    String parentWindow = driver.CurrentWindowHandle;
    IList<IWebElement> links = driver.FindElements(By.ClassName("popup"));
    
    for (int i = 0; i < links.Count; i++)
    {                                               
         IWebElement welcomePopup = driver.FindElement(By.XPath(string.Format("//div[@id='Buttons']/table/tbody/tr/td/table/tbody/tr/td[contains(text(),'" + links[i].Text + "')]")));
         PopupWindowFinder popupFinder = new PopupWindowFinder(driver);
         string welcomePopupHandle = popupFinder.Click(welcomePopup);
    
         if (!string.IsNullOrEmpty(links[i].Text))
         driver.SwitchTo().Window(welcomePopupHandle);
         driver.FindElement(By.Id("cmdClose")).Click();  
         driver.SwitchTo().Window(parentWindow);              
    }
