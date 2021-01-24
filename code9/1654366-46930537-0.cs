    context.MapRoute(
        "AdminDefaultNoAction",
        "Admin/{controller}/{id}",
        new { action = "Home", id = UrlParameter.Optional },
        new { id = @"[a-f0-9-]+" },
        new[] { "DevTest.Areas.Admin.Controllers" }
    );
