    public static void WaitUntilInvisible(this Browser browser, By element, int seconds = 30)
            {
                var wait = new WebDriverWait(browser.Driver, new TimeSpan(0, 0, seconds));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
            }
