    driver.Navigate().GoToUrl(baseURL);
    driver.FindElement(By.Id("MainContent_LoginCtrl_UserName")).Clear();  		  
    driver.FindElement(By.Id("MainContent_LoginCtrl_UserName")).SendKeys("name");
    driver.FindElement(By.Id("MainContent_LoginCtrl_Password")).Clear();      
    driver.FindElement(By.Id("MainContent_LoginCtrl_Password")).SendKeys("password");     
    Thread.Sleep(10000);
    driver.FindElement(By.Id("MainContent_LoginCtrl_Password")).Click();
