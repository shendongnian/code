        public static void RegisterRoutes(RouteCollection routes) {
            routes.MapRoute(
                "Items",
                "Item/{slug}/{id}",
                 new { controller = "Item", action = "Index" });
        }
