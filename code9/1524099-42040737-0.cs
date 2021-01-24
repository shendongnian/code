    public static Func<IWebElement, ReadOnlyCollection<IWebElement>> PresenceOfAllElementsLocatedBy(By locator)
    {
        return (element) =>
        {
            try
            {
                var elements = element.FindElements(locator);
                return elements.Any() ? elements : null;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        };
    }
