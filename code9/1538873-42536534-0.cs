        protected void Application_Start()
        {            
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Telerik.Reporting.Services.WebApi.ReportsControllerConfiguration.RegisterRoutes(System.Web.Http.GlobalConfiguration.Configuration);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.RegisterMaps();
        }
