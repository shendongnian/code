    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Other stuff
            
            routes.MapMvcAttributeRoutes(); //make sure this is there
        }
    }
