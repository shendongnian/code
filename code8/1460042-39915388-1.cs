    private IWebDriver GetSauceLabsDriver()
    {
        var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        ChromeOptions options = new ChromeOptions();
        options.AddExtensions(outPutDirectory + @"\3.1.3_0.
        
        // Add capabilities that belong at the top
        // level of the capabilities object as opposed
        // to part of the chromeOptions capability. Note
        // that setting the browser name is entirely 
        // redundant and thus is not done. Likewise,
        // deviceName and deviceOrientation are 
        options.AddAdditionalCapability(CapabilityType.Version, "53.0", true);
        options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);
        options.AddAdditionalCapability("username", "kin", true);
        options.AddAdditionalCapability("accessKey", "9cd6-438e-a9635b70953d", true);
        options.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);
        return new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options.ToCapabilities(),
            TimeSpan.FromSeconds(600));
    }
