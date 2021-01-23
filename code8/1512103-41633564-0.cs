    protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                ControllerBuilder.Current.DefaultNamespaces.Add("Stock.Controllers"); // Add This
            }
