      //call the method and pass the xpath. You can also create css, id etc. 
      page.WaitForElementNoLongerDisplayed_byXpath("//div[contains(@class, 'my-error-message')]");
       
	   public static void WaitForElementNoLongerDisplayed_byXpath(string elementXpath)
        {
            try
            {
                _wait.Until(driver => driver.FindElements(By.XPath(elementXpath)).Count == 0);
            }
            catch (Exception)
            {
                LogFunctions.WriteError("Element is still displayed and should not be");
                TakeScreenshot("elementStillShown");
                throw;
            }
        }
