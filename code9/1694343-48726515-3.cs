    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            routes.MapServiceRoute("AddRoute", "service/ldfdsfsdf/dsd3dfd3d", "~/service/myoriginal.asmx?op=Add");
            routes.MapServiceRoute("SubtractRoute", "service/ldfdsfsdf/dsd3dfd3g", "~/service/myoriginal.asmx?op=Subtract");
            routes.MapServiceRoute("MultiplyRoute", "service/ldfdsfsdf/dsd3dfd3k", "~/service/myoriginal.asmx?op=Multiply");
            routes.MapServiceRoute("DivideRoute", "service/ldfdsfsdf/dsd3dfd3v", "~/service/myoriginal.asmx?op=Divide");
        }
    }
