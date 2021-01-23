    using System.Web.Mvc;
    using System.Web.Routing;
    
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.MapMvcAttributeRoutes();
        }
    }
