    public static void RegisterRoutes(RouteCollection routes) {
        routes.MapRoute(
            name: "Items",
            url: "Item/{id}/{*slug}",
            defaults: new { controller = "Item", action = "Index", slug = RouteParameter.Optional }
        );
    }
