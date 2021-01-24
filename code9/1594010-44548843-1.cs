        public class OrderPage : Page
        {
            [FindsBy(How = How.Name, Using = "Username")]
            private IWebElement usernameField;
        
            [FindsBy(How = How.Name, Using = "ValidToDateTime")]
            private IWebElement dateToField;
    
    public OffersPage(IWebDriver browser, Report report, Validations validations)
                : base(browser, report, validations)
            {
                //Constructor
            }
        
        
            public string validateField(string expectedText) //method to validate field
            {
                try
               {
                   string actualText = usernameField.GetAttribute("text");
                   if (actualText.ToLower().Trim().Equals(expectedText))
                   {
                       validations.assertionPass("validateField", "Expected text displays as expected.");
                    }
                    else
                    {
                        validations.assertionFailed("validateField", "The expected text does not display as expected " + actualText + " displays instead.");
                    }
               }
               catch (Exception ex)
               {
                  //this is typically where I put my report method
                  //but I'm not including it in the rest of the example 
                  //because you didn't ask how to generate reports and this 
                  //is just a way to put the exception thrown in the html 
                  //report. You could just as easily throw the exception 
                   //here if need be
                  report.reportException(ex, "validateField");
               }
        }
