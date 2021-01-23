    protected void Application_Start()
    {
         AreaRegistration.RegisterAllAreas();
         //next line registers web api routes
         GlobalConfiguration.Configure(WebApiConfig.Register);
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         //next line registers mvc routes
         RouteConfig.RegisterRoutes(RouteTable.Routes); 
         BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
