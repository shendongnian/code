    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings, new WebMethodFriendlyUrlResolver());
        }
    }
    public class WebMethodFriendlyUrlResolver : WebFormsFriendlyUrlResolver
    {
        public override string ConvertToFriendlyUrl(string path)
        {
            if (HttpContext.Current.Request.PathInfo != string.Empty)
            {
                return path;
            }
            else
            {
                return base.ConvertToFriendlyUrl(path);
            }
        }
    }
