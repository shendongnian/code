    public static class UrlHelperExtensions
    {
        private static IODataPathHandler _pathHandler = new DefaultODataPathHandler();
        public static string ODataUrl(this UrlHelper urlHelper, string routeName, params ODataPathSegment[] segments)
        {
            var odataPath = _pathHandler.Link(new ODataPath(segments));
            return urlHelper.Route(routeName, new RouteValueDictionary() { { ODataRouteConstants.ODataPath, odataPath } });
        }
    }
