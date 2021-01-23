    routes.MapRoute(
        "API",
        "api/{controller}/{action}/{id}",
        new { controller = "Home", action = "Index", id = UrlParameter.Optional     },
        new[] { "MyMvcApp.Api" }
    );
    routes.MapRoute(
        "Default",
        "{controller}/{action}/{id}",
        new { controller = "Home", action = "Index", id = UrlParameter.Optional },
        new[] { "MyMvcApp.Controllers" }
    );
