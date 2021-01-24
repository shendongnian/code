    public static bool FindElement
        {
          get
          {
              try
              {
                 var element = Driver.BrowserInstance.FindElement(By.XPath("  "));
                 if (element != null)
                 {
                   return true;
                 }
              }
              catch (Exception ex)
              {
                 Logging.ErrorScreenshot();
                 Logging.Error("Not able to find element" + ex.ToString());
              }
              return false;
         }
    
      }
