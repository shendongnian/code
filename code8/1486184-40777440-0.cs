    public class AreaGeneralAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreaGeneral";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaGeneral_default",
                "AreaGeneral/{controller}/{action}/{id}",
                new { controller = "Home", action = "GetData", id = UrlParameter.Optional }
            );
        }
    }
