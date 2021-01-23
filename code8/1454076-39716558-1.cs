    driver.Navigate().GoToUrl(baseURL);
    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
    driver.FindElement(By.Id("MainContent_LoginCtrl_UserName")).Clear();
    driver.FindElement(By.Id("MainContent_LoginCtrl_UserName")).SendKeys("name");
    driver.FindElement(By.Id("MainContent_LoginCtrl_Password")).Clear();      
    driver.FindElement(By.Id("MainContent_LoginCtrl_Password")).SendKeys("password");     
    driver.FindElement(By.Id("MainContent_LoginCtrl_Password")).Click();
