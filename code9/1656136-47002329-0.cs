    public class MvcApplication : NinjectHttpApplication
    {
       public static void RegisterGlobalFilters(GlobalFilterCollection filters)
       {
           filters.Add(new HandleErrorAttribute());
       }
     
       public static void RegisterRoutes(RouteCollection routes)
       {
           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
     
           routes.MapRoute(
               "Default", // Route name
               "{controller}/{action}/{id}", // URL with parameters
               new
               {
                   controller = "Home",
                   action = "Index",
                   id = UrlParameter.Optional
               });
       }
     
       protected override IKernel CreateKernel()
       {
           var kernel = new StandardKernel();
           RegisterServices(kernel);
           return kernel;
       }
    
       /// <summary>
       /// Load your modules or register your services here!
       /// </summary>
       /// <param name="kernel">The kernel.</param>
       private void RegisterServices(IKernel kernel)
       {
           // e.g. kernel.Load(Assembly.GetExecutingAssembly());
       }
     
       protected override void OnApplicationStarted()
       {
           base.OnApplicationStarted();
     
           AreaRegistration.RegisterAllAreas();
           RegisterGlobalFilters(GlobalFilters.Filters);
           RegisterRoutes(RouteTable.Routes);
       }
    }
