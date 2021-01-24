    public bool IsElementClickable(By locator, int timeOut)
    {
        try
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut)).Until(ExpectedConditions.ElementToBeClickable(locator));
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
