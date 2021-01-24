    Class WebElementFinder
    {
       public static IWebElement FindElement(ISearchContext sc, By locator, Func<IWebElement, bool> elementCondition = null, int timeOutInceconds = 20)
            {
                DefaultWait<ISearchContext> wait = new DefaultWait<ISearchContext>(sc);
                wait.Timeout = TimeSpan.FromSeconds(timeOutInceconds);
                wait.PollingInterval = TimeSpan.FromSeconds(3);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                
                return  wait.Until(x => GetElement(x, locator, elementCondition));
            }
    
            private static IWebElement GetElement(ISearchContext sc, By locator, Func<IWebElement, bool> elementCondition = null)
            {
                 IWebElement webElement = sc.FindElement(locator);
                 if(elementCondition != null)
                {
                    if (elementCondition(webElement))
                        return webElement;
                    else
                        return null;
                }
                 else
                {
                    return webElement;
                }
            }
    }
