      public static class SeleniumExtensionMethods {
          public static WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
          public static void SafeClick(this IWebElement webElement) {
              try {
                  wait.Until(ExpectedConditions.ElementToBeClickable(webElement)).Click();
              } catch (TargetInvocationException ex) {
                  Console.WriteLine(ex.InnerException);
              }
    
          }
