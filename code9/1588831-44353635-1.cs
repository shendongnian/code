    public BrowserFactory()
            {
                Driver = new FirefoxDriver();
            }
    
            public static IWebDriver Driver
            {
                get
                {
                 
                    return driver;
                }
                private set
                {
                    driver = value;
                }
            }
