    public class MvcApplication : System.Web.HttpApplication
    {
         protected void Application_Start()
         {
             AreaRegistration.RegisterAllAreas();
             RouteConfig.RegisterRoutes(RouteTable.Routes);
             AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
         }
    }
}
