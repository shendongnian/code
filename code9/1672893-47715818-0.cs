    public static void WaitOnPageForXPathClickable(string selector)
    {
    	IWebElement element = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementToBeClickable((By.XPath(//label[@class='replaced-input-label replaced-input-label--radio']))));
        elementClick();
    }
