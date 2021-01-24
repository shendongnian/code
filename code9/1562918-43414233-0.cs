    public class Find
    {
        public static IWebElement Element(WebDriverWait wait, Func<IWebDriver, IWebElement> expectedCondition)
        {
            return wait.Until(expectedCondition);
        }
        public static IReadOnlyCollection<IWebElement> Elements(WebDriverWait wait, Func<IWebDriver, IReadOnlyCollection<IWebElement>> expectedCondition)
        {
            return wait.Until(expectedCondition);
        }
    }
