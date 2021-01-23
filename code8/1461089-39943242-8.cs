     public static class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                var settings = new FriendlyUrlSettings();
                settings.AutoRedirectMode = RedirectMode.Off;//Its may cause the error
                routes.EnableFriendlyUrls(settings);
            }
        }
