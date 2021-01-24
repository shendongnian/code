    public void ConfigureServices(IServiceCollection services)
    {
        //All your other DI stuff here
        //register the new ValidationHtmlAttributeProvider
        services.AddSingleton<ValidationHtmlAttributeProvider, PseudoAttributeValidationHtmlAttributeProvider>();
    }
