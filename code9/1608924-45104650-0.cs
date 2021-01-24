    public static void WaitForLoading(this Browser browser)
    {
        new WebDriverWait(browser.Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loading")));
    }
    public static void WaitForProgressBar(this Browser browser)
    {
        new WebDriverWait(browser.Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("(//*[@class='progress-bar'])[2]")));
    }
    public static void WaitForSpinner(this Browser browser)
    {
        new WebDriverWait(browser.Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("spinner")));
    }
