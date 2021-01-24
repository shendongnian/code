        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            RegisterCustomRoutes(RouteTable.Routes);
        }  
        public static void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "Main",
                "Accessories/",
                "~/Product.aspx"
            );
        }  
