    // <param name="locator">The locator used to find the element.</param>
    // <returns>The <see cref="IWebElement"/> once it is located, visible and clickable.</returns>
    public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
    {
        return driver =>
        {
            var element = driver.FindElement(locator);
            return (element != null && element.Displayed && element.Enabled) ? element : null;
        };
    }
