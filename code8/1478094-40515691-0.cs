    internal void ClickUpdateButton(TimeSpan timeout)
    {
        WebDriverWait wait = new WebDriverWait(_driver, timeout);
        wait.Until(ExpectedConditions.visibilityOf(UpdateButton)).click();
    }
