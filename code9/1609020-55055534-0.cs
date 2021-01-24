        public static Microsoft.AspNet.OData.Routing.ODataPath CreateODataPath(this HttpRequest request, Uri uri)
        {
            var pathHandler = request.GetPathHandler();
            var serviceRoot = request.GetUrlHelper().CreateODataLink(
                                    request.ODataFeature().RouteName,
                                    pathHandler,
                                    new List<ODataPathSegment>());
            return pathHandler.Parse(serviceRoot, uri.LocalPath, request.GetRequestContainer());
        }
        public static TKey GetKeyValue<TKey>(this HttpRequest request, Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }
            //get the odata path Ex: ~/entityset/key/$links/navigation
            var odataPath = request.CreateODataPath(uri);
            var keySegment = odataPath.Segments.OfType<KeySegment>().LastOrDefault();
            if (keySegment == null)
            {
                throw new InvalidOperationException("This link does not contain a key.");
            }
            return (TKey)keySegment.Keys.First().Value;
        }
