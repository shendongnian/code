    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }
    
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{language}/{controller}/{action}/{id}",
                new { language = "en-US", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
