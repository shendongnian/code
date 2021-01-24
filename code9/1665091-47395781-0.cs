    public void SelectReasonsToBookWithUsLinks(string itemName, string linkText) {
        var wait = new DefaultWait<IWebDriver>(_driver);
        wait.IgnoreExceptionTypes(
          typeof(System.InvalidOperationException),
          typeof(InvalidElementStateException),
          typeof(ElementNotVisibleException),
          typeof(StaleElementReferenceException)
        );
      
        wait.Until(drv => {
            drv.FindElements(HomepageResponsiveElements.BookWithUsLinks)
               .Single(elm => elm.Text == linkText)
               .Click();
            return true;
          });
    }
