        public static void WaitAndClick(this IWebDriver driver, IWebElement webelement)
        {
            var fluentWait = new WebDriverWait(driver, Configuration.WaitTime);
            fluentWait.Until(webDriver =>
            {
                try
                {
                    webelement.Click();
                }
                catch (Exception ex)
                {
                    if (ex is TargetInvocationException ||
                        ex is NoSuchElementException ||
                        ex is InvalidOperationException)
                    {
                        return false; //By returning false, wait will still rerun the func.
                    }
                    {
                        throw; //Rethrow exception if it's not ignore type.
                    }
                }
                return true;
            });
        }   
