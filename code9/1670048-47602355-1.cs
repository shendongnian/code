    IWebElement elem = driver.FindElement(By.Id("login-form"));
    
    	elem.FindElement(By.Id("inputEmail")).Clear();
    	elem.FindElement(By.Id("inputEmail")).SendKeys("test@gmail.com");
    	
    	elem.FindElement(By.Id("inputPassword")).Clear();
    	elem.FindElement(By.Id("inputPassword")).SendKeys("test@gmail.com");
    	
    	elem.FindElement(By.CssSelector("button[type='submit']")).Click();
