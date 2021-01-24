    public static void WaitForElementPresent(this IWebDriver driver, ElementType elementType, string element)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(ExpectedConditions.ElementIsVisible(GetElement(elementType, element)));
    }
