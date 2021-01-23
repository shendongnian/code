    public WebElement waitThenClick(WebElement element) 
    {
        WebDriverWait wait = new WebDriverWait(_driver, timeout);
        return wait.Until(ExpectedConditions.visibilityOf(UpdateButton)).click();
    }
