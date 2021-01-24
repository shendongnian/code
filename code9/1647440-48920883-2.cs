    protected void Application_Start()
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<MsSqlDbContext, Configuration>());
        AreaRegistration.RegisterAllAreas();
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
     }
