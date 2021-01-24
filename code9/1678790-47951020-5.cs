    public class ClientAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Client";
            }
        }
    
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Client_default",
                "Client/{language}/{controller}/{action}/{id}",
                new { language = "en-US", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
