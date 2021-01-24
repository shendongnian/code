    public bool IsAlertPresentAndCorrect(string Message)
    {
        try
        {
            WebDriverWait Wait = new WebDriverWait(Driver, System.TimeSpan.FromSeconds(10));
            Wait.Until(ExpectedConditions.AlertIsPresent());
            string alertText = Driver.SwitchTo().Alert().Text;
    		Driver.SwitchTo().Alert().Accept();
            return alertText.Equals(Message);
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }
