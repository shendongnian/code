    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
    public class WebApiApplication : System.Web.HttpApplication
    {
      protected void Application_Start()
      {
        UnityConfig.RegisterComponents();
      }           
    }  
