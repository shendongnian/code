    public static void WaitForElement(this IWebElement element, IWebDriver 
     driver, int waitTime)
            {            
                try{                
                     var wait = new WebDriverWait(driver, timeSpan.FromSeconds(waitTime));
                     wait.Until(ExpectedConditions.ElementToBeClickable(element));
                     Logging.Information(elementText + " is clickable");
                   }
                   catch (NoSuchElementException)
                   {
                        throw new Exception("Could not find the" + Xpath + "Xpath after" + DefaultWaitTime + "second");
                   }
                }
            }
