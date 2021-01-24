    void Application_Start(object sender, EventArgs e)
    {
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        ModelBindersConfig.Configure();
        DevExpressConfig.Configure();
        AutoMapperConfig.Configure();          
    }
