    public void ConfigureServices(IServiceCollection services)
    {
      services.AddRazorPages();
      services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
    }
