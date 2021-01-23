    public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapMvcAttributeRoutes();
            context.MapRoute(
                "RetailersAssistance_default",
                "ra/{controller}/{action}/{id}",
                new { controller = "Login", action = "Test", id = UrlParameter.Optional },
                new[] { "SkyTracker.Areas.RetailersAssistance.Controllers" }
            );
        }
