    public static bool IsElementPresent(this IWebElement webElement, By by)
         {
                try
                {
                    webElement.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
