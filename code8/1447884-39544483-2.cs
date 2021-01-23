    public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			UnityConfig.RegisterComponents();
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);            
		}      
	}
