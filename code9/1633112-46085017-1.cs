    try
    {
        if (driver.FindElement(By.XPath("xpath")) != null)
        {
            IWebElement buttonclick = driver.FindElement(By.XPath("xpath"));
            buttonclick.Click();
        }
    }
    catch (Exception e)
    {
        //in case there is an exception
    }
