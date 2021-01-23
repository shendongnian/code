    public class NewAreaRegistration : AreaRegistration
    {
            public override string AreaName
            {
                get
                {
                    return "NewArea";
                }
            }
    
            public override void RegisterArea(AreaRegistrationContext context)
            {
                context.MapRoute(
                    "NewArea", // Route name
                    "NewArea/{action}/{id}", // URL with parameters
                    new { controller = "NewArea", action = "Index"  } // Parameter defaults
                );
            }
    }
