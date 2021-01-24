    protected void Application_Start()
    {
        GlobalConfiguration.Configure(WebApiConfig.Register);
        GlobalConfiguration.Configuration.Filters.Add(new AuthFilter());
        GlobalConfiguration.Configuration.Filters.Add(new ActionFilter());
    }
