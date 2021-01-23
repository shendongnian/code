    public static IWebElement WaitUntilElementIsVisible(this IWebDriver driver, IWebElement element, int timeOutInSeconds = DefaultTimeoutSeconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                return wait.Until(ExpectedConditions.ElementIsVisible(element)); //Wait finishes when return is a non-null value or 'true'
            }
            catch (NoSuchElementException ex)
            {
                MethodLogger.OutputLog($"Element: {element} was not found on current page.");
                MethodLogger.OutputLog(ex);
                return null;
            }
            catch (WebDriverTimeoutException)
            {
                MethodLogger.OutputLog($"Timed out Looking for Clickable Element; {element}: Waited for {timeOutInSeconds} seconds.");
                return null;
            }
        }
