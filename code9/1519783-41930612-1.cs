        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Add filter for resetting contractresolver
            var filters = System.Web.Http.GlobalConfiguration.Configuration.Filters;
            filters.Add(new ResetSerializeContractResolverFilter());
        }
