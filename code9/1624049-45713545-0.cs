    public static void WaitForEnabled (string xpath) {
            var wait = new WebDriverWait(GCDriver.Instance,  
                       TimeSpan.FromSeconds(10));
            wait.Until(driver => 
            driver.FindElement(By.XPath(xpath)).Enabled);
    }
