    while (driver.FindElements(By.Id("MainContent_LoginCtrl_UserName")).Count > 0 || driver.FindElements(By.Id("MainContent_LoginCtrl_Password")).Count > 0) {
                driver.FindElement(By.Id("MainContent_LoginCtrl_UserName")).Clear();
                driver.FindElement(By.Id("MainContent_LoginCtrl_UserName")).SendKeys("username");
                driver.FindElement(By.Id("MainContent_LoginCtrl_Password")).Clear();
                driver.FindElement(By.Id("MainContent_LoginCtrl_Password")).SendKeys("password");
                driver.FindElement(By.Name("ctl00$MainContent$LoginCtrl$ctl05")).Click();
                Thread.Sleep(5000);
            }
