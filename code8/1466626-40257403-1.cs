    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        public void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var userId = HttpContext.Current.Request["UserGUID"];
            if (userId != null)
            {
                Session["UserGuid"] = Guid.Parse(userId.ToString());
                //My logic for session handling..
            }
        }
    }
