    public static void WaitAndClick(this IWebDriver driver, IWebElement webelement)
        {
            var fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configuration.WaitTime.TotalSeconds));
            fluentWait.Until( Driver =>
            {
                try
                {
                    webelement.Click();
                }
                catch (Exception ex)
                {
                    var exType = ex.GetType();
                    if (exType == typeof(TargetInvocationException) ||
                        exType == typeof(NoSuchElementException) ||
                        exType == typeof(InvalidOperationException))
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
