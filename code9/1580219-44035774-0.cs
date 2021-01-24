    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddAntiforgery(x => x.HeaderName = "X-XSRF-TOKEN");
    	services.AddMvc();
    }
