    /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page
        /// and visible. Visibility means that the element is not only displayed but
        /// also has a height and width that is greater than 0.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="T:OpenQA.Selenium.IWebElement" /> once it is located and visible.</returns>
        public static Func<IWebDriver, IWebElement> ElementIsVisible(IWebElement element) => driver =>
        {
            try
            {
                return ElementIfVisible(element);
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        };
        private static IWebElement ElementIfVisible(IWebElement element)
        {
            if (!element.Displayed)
                return null;
            return element;
        }
