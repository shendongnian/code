    using System.Web.Mvc;
    using System.Web.Routing;
    using Enterprise.Apps.Shared.Web;
    
    namespace Enterprise.Apps.Web
    {
        public class MvcApplication : System.Web.HttpApplication
        {
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    
                // Use only LayoutWrapperViewEngine
                ViewEngines.Engines.Clear();
                ViewEngines.Engines.Add(new LayoutWrapperViewEngine());
    
                RouteConfig.RegisterRoutes(RouteTable.Routes);
            }
        }
    }
