    [FindsBy(How = How.Id, Using = "Passwd")]
    public IWebElement Password {get;set;}
    
    [FindsBy(How = How.Id, Using = "signIn")]
    public IWebElement Signin { get; set; }
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    wait.Until(Password.Displayed);
