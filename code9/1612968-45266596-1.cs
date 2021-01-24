    IWebElement inputus = Driver.Instance.FindElement(By.XPath(".//*[@id='onboarding']/div[2]/form/section[2]/div/div[1]/input"));
            inputus.SendKeys(username);
          
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10.00);
            var inputpass = Driver.Instance.FindElement(By.Name("password"));
            inputpass.SendKeys(password);
            Driver.Instance.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10.00);
            var loginbutton = Driver.Instance.FindElement(By.ClassName("traditional-login"));
            loginbutton.Click();
