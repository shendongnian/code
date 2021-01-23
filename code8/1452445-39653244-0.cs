    using Microsoft.Practices.Unity;
    public class MvcApplication : System.Web.HttpApplication
        {
            private readonly IGenreService _genreService;
            public MvcApplication()
            {
                _genreService = GameCommerce.Web.App_Start.UnityConfig.GetConfiguredContainer().Resolve<IGenreService>();
            }
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
        }
