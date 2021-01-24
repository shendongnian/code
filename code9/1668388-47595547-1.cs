    public class GCDriver
    {
        public static void WaitForVisible(By locator, TimeSpan timeout)
        {
            new WebDriverWait(GCDriver.Instance, timeout).Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
