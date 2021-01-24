     public class CommonSteps
        {
            protected IWebDriver browser;
            protected HomePage homePage;
            protected Validations validations;
    
            [BeforeScenario]
            public void BeforeScenario()
            {
                //code to initializeBrowser();
    
                 //code to initializevalidationsObject();
    
                 //code to openApplication();
    
            }
    
            [AfterScenario]
            public void AfterScenario()
            {
                try
                {
                    //code to close the application safely
                }
                catch (WebDriverException)
                {
    
                }
    
                finally
                {
    
                }
            }
    }
