    protected void Application_Start()
    {
         AreaRegistration.RegisterAllAreas();
         FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         BundleConfig.RegisterBundles(BundleTable.Bundles);
         Database.SetInitializer<MyContext>(null);
         new MyContext().CreateDefaultUsers();
    }
