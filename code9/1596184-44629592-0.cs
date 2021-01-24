     private static WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
     public static void WaitUntilAttributeValueEquals(this IWebElement webElement, String attributeName, String attributeValue)
        {           
                wait.Until<IWebElement>((d) =>
                {
                    //var x = webElement.GetAttribute(attributeName); //for debugging only
                    if (webElement.GetAttribute(attributeName) == attributeValue) 
                    {
                        return webElement;
                    }
                    return null;
                });
            }
