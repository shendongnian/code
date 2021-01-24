    public bool isElementVisible(By locator)
    {
        try
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(0)).Until(ExpectedConditions.ElementExists(locator));
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(0)).Until(ExpectedConditions.ElementIsVisible(locator));            
            }
            catch (WebDriverTimeoutException)
            {
                //Element exists but is not visible, return false or do other stuff
                return false
            }
        }
        catch (WebDriverTimeoutException)
        {
            //Element does not exist, return false or do other stuff
            return false;
        }
        //If code reaches this point, element both exists and is visible
        return true;
    }
