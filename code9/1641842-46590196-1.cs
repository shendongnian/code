    public abstract class CustomAreaRegistration : AreaRegistration
    {
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                AreaName + "Ajax",
                AreaName + "/{controller}/{action}",
                new { action = "Index" }
            );
            context.MapRoute(
                AreaName + "ShortUrl",
                AreaName + "/{controller}",
                new { action = "Index", controller = "Dashboard" }
            );
        }
    }
