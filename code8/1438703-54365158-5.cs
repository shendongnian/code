    protected void Application_Start()
    {
       AreaRegistration.RegisterAllAreas();
       GlobalConfiguration.Configure(RouteConfig.Register); // WEB API 1st
       FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
       RouteConfig.RegisterRoutes(RouteTable.Routes); // MVC 2nd
       BundleConfig.RegisterBundles(BundleTable.Bundles);
    } 
