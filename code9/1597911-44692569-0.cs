    public void ConfigureServices(IServiceCollection services)
    {
    	services.Configure<RequestLocalizationOptions>(options =>
    	{
    		options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-NZ");
    		options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), new CultureInfo("en-NZ") };
    	});
    
    	services.AddMvc();
    }
