    public static class SessionUtils
    {
        public class SessionContent
        {
            public XClass xProperty{ get; set; }
            public YClass yProperty{ get; set; }
        }
        public static string GetSessionGUID(IHttpRouteData route)
        {
            return route.Values["guid"].ToString();
        }
        public static XClass GetSessionXProperty(HttpContextBase httpContextBase, IHttpRouteData route)
        {
            return ((SessionUtils.SessionContent)httpContextBase.Session[GetSessionGUID(route)]).xProperty;
        }
        public static void SetSessionXProperty(HttpContextBase httpContextBase, IHttpRouteData route, XClass xProperty)
        {
            ((SessionUtils.SessionContent)httpContextBase.Session[GetSessionGUID(route)]).xProperty= xProperty;
        }
        public static YClass GetSessionYProperty(HttpContextBase httpContextBase, IHttpRouteData route)
        {
            return ((SessionUtils.SessionContent)httpContextBase.Session[GetSessionGUID(route)]).yProperty;
        }
        public static void SetSessionYProperty(HttpContextBase httpContextBase, IHttpRouteData route, YClass yProperty)
        {
            ((SessionUtils.SessionContent)httpContextBase.Session[GetSessionGUID(route)]).yProperty= yProperty;
        }
    }
