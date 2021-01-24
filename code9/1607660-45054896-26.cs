    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
        protected void Session_Start()
        {
            // 'using' will call entity.Dispose() at the end of the block so you
            // don't have to bother about disposing your entity
            using(OnlineStoreEntities entity = new OnlineStoreEntities()){
                HttpContext context = HttpContext.Current;
                if(context != null && context.Session != null)
                    // fill the Session var with the Categories from your database
                    context.Session["Categories"] = entity.Categories.ToList();
            }
        }
    }
