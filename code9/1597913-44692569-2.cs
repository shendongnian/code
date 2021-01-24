    public void ConfigureServices(IServiceCollection services)
    {
    	services.Configure<RequestLocalizationOptions>(options =>
    	{
    		options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-GB");
    		options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-GB") };
    		options.RequestCultureProviders.Clear();
    	});
    
    	services.AddMvc();
    }
