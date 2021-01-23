    namespace ParallelTests
    {
        public static class ExtensionMethods // I would call it ChromeDriverEntension
        {
            public static void AssertDisplayed(this IWebDriver driver)
            {
                Assert.IsTrue(driver.FindElement(By.XPath("//*[contains(text(),'Some Text')]")).Displayed);
            }
        }
    } 
