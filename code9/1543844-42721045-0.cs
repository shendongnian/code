    routes.MapRoute(
                "Default", // Route name
                "Namespace2/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Namespace2.Controllers" });
    routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Namespace1.Controllers" });
