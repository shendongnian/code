        public static bool IsElementPresent_byCssSelector(string elementName)
        {
            try { Driver.FindElement(By.CssSelector(elementName)); }
            catch (NoSuchElementException) { return false; }
            catch (StaleElementReferenceException) { return false; }
            return true;
        }
    var test = driver.IsElementPresent_byCssSelector("a[data-value*='09.0']");
    if(test)
    {
     //do something
    }
