        using Microsoft.Extensions.Localization;
        using Microsoft.Extensions.Logging.Abstractions;
        using Microsoft.Extensions.Options;
        
        ...
        
    public void MyTest() 
    {
        var options = Options.Create(new LocalizationOptions());  // you should not need any params here if using a StringLocalizer<T>
        var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);
        var localizer = new StringLocalizer<MyResourceFile>(factory);
        var myText = localizer["myText"];  // text using default culture
        CultureInfo.CurrentCulture = new CultureInfo("fr");
        var myFrenchText = localizer["myText"];  // text in French
    
    }
