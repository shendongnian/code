    Class WebElementFinder
    {
     private static IWebElement FindElement(ISearchContext sc, By locator, int timeOutInceconds = 20)
            {
                DefaultWait<ISearchContext> wait = new DefaultWait<ISearchContext>(sc);
                wait.Timeout = TimeSpan.FromSeconds(timeOutInceconds);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                return wait.Until(x => GetElement(x, locator));
            }
    
            private static IWebElement GetElement(ISearchContext sc, By locator)
            {
               return sc.FindElement(locator);
            }
    }
