    public class MvcApplication : System.Web.HttpApplication
        {
            protected void Application_Start()
            {
                //Database.SetInitializer<MyDBContext>(.....);
                AreaRegistration.RegisterAllAreas();
                RouteConfig.RegisterRoutes(RouteTable.Routes);
            }
        }
