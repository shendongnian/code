    public static boid WaitForAlert(bool accept)
    {
        //Initialize your wait.
        WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
        //Wait for alert
        try
        {
            wait.Until(ExpectedConditions.AlertIsPresent());    
            if (accept)
            {
                Driver().Instance.SwitchTo().Alert().Accept();
            }
            else
            {
                Driver().Instance.SwitchTo().Alert().Dismiss();
            }    
        }
        catch (WebDriverTimeoutException) { /*Alert did not appear, do nothing*/ }
    }
