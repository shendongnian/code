    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            routes.MapServiceRoutes(new Dictionary<string, string>
            {
                { "service/ldfdsfsdf/dsd3dfd3d", "~/service/myoriginal.asmx?op=Add" },
                { "service/ldfdsfsdf/dsd3dfd3g", "~/service/myoriginal.asmx?op=Subtract" },
                { "service/ldfdsfsdf/dsd3dfd3k", "~/service/myoriginal.asmx?op=Multiply" },
                { "service/ldfdsfsdf/dsd3dfd3v", "~/service/myoriginal.asmx?op=Divide" },
            });
        }
    }
