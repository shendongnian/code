    public static void WaitForLocator(this IWebDriver driver, By by, int waitTime)
        {
            Logging.Action("Using locator: " + by + " to find element");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            wait.Until(ExpectedConditions.ElementToBeClickable(by)); //There are several Expected conditions
            Logging.Information("Found element with locator: " + by);
        }
