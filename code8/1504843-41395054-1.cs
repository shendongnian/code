     public class WebApiApplication : HttpApplication
        {
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
    
              
                // Register Mapping Configuration on Start up
                AutoMapperConfiguration.Configure();
               
            }
    
            protected void Application_End()
            {
                //Cleanup all resources
               
            }
        }
