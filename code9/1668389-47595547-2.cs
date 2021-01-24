    public class GCDriver
    {
        public static void Wait(Func<IWebDriver, IWebElement> func, TimeSpan timeout)
        {
            new WebDriverWait(GCDriver.Instance, timeout).Until(func);
        }
    }
