    IWebElement division = driver.FindElement(By.XPath("//div[@id='form-info']"));
    division.FindElement(By.TagName("input")).SendKeys("text to enter");
    for (int i = 0; i < 2; i++)
    {
         division.FindElement(By.TagName("button")).Click();
         Thread.Sleep(2000);
         division = driver.FindElement(By.XPath("//div[@id='form-info']"));
         Thread.Sleep(2000);
         division.FindElements(By.TagName("input"))[i+1].SendKeys("text to enter");
    }
