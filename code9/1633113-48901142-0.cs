     private bool IsControlPresent(By Control)
        {
            try
            {
                
                WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                WebDriver.FindElement(Control);
                WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
