    public class Button
    {
        public static void Click(By locator)
        {
            Find(locator).Click();
        }
        private static IWebElement Find(By locator)
        {
            return GCDriver.Instance.FindElement(locator);
        }
    }
