     protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);//for register route
            BundleConfig.RegisterBundles(BundleTable.Bundles);//for register bundle
        }
