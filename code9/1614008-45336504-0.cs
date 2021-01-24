    public class PagesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Pages";
            }
        }
        public static AreaRegistrationContext AreaContext { get; set; }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			// save context to static for later use
            AreaContext = context;
            // get customers
            List<Customer> custs = new CustBLL().getActiveCustomers();
            // get list of domain urls
            string urlList = string.Join("|", custs.Select(c => c.UrlIdentifier).ToArray());
            
			// map customer URLs
            context.MapRoute(
                "Pages_CUSTURL", // Route name
                "Pages/{CUSTURL}/{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                constraints: new { CUSTURL = urlList }
            );
			// general area mapping
            context.MapRoute(
                "Pages_default",
                "Pages/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { controller = new ControllerConstraint() }
            );
        }
        public static void UpdateRouteRegistration(string newURLID)
        {
			// get context from static member
            RouteCollection routes = AreaContext.Routes;
			// get write lock to avoid threading issues
            using (routes.GetWriteLock())
            {
                // add new company url to route table 
                AreaContext.MapRoute(
                    "Pages_CUSTURL_" + newURLID,                                      // Route name
                    "Pages/{CUSTURL}/{controller}/{action}/{id}",                       // URL with parameters
                    new { controller = "Home", action = "Index", id = UrlParameter.Optional },  // Parameter defaults
                    constraints: new { CUSTURL = newURLID }
                );
            }
        }
    }
