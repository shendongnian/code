    public void ConfigureServices(IServiceCollection services)
            {
                services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
                services.AddMvc();
            }
