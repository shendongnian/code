    public IWebDriver driver = null;
    [BeforeScenario]
    public void BeforeScenario()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--incognito");
        options.AddArguments("start-maximized");
        webDriver = new ChromeDriver(options);
        webDriver.Navigate().GoToUrl("URL");
    }
    [AfterScenario]
    public void AfterScenario()
    {
        if (driver == null)
        {
            throw new Exception("Driver is null, call BeforeScenario() first.");
        }
        driver.Quit();
    }
