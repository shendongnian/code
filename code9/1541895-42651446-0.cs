    public static void StartSauceDriver(string Title)
        {
            {
                    DesiredCapabilities caps = new DesiredCapabilities();
                    caps.SetCapability(CapabilityType.BrowserName, System.Environment.GetEnvironmentVariable("SELENIUM_BROWSER"));
                    caps.SetCapability(CapabilityType.Version, System.Environment.GetEnvironmentVariable("SELENIUM_VERSION"));
                    caps.SetCapability(CapabilityType.Platform, System.Environment.GetEnvironmentVariable("SELENIUM_PLATFORM"));
                    caps.SetCapability("name", Title);
                    _webDriver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com/wd/hub"), caps, TimeSpan.FromSeconds(600));
                    _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(600));
                
            }
