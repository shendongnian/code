    public class UrlToRouteMapper
    {
        public static RouteValueDictionary GetRouteDataFromURL(string absoluteURL)
        {
            var testUrl = "~" + new Uri(absoluteURL).AbsolutePath;
            var context = new StubHttpContextForRouting(requestUrl: testUrl);
            var routes = new System.Web.Routing.RouteCollection();
            MvcApplication.RegisterRoutes(routes);
    
            System.Web.Routing.RouteData routeData = routes.GetRouteData(context);
    
            return routeData.Values;
        }
    
        public static string GetEndpointStringFromURL(string absoluteURL)
        {
            var routeData = GetRouteDataFromURL(absoluteURL);
            return routeData["controller"] + "/" + routeData["action"];
        }
    
    }
    
    public class StubHttpContextForRouting : HttpContextBase {
        StubHttpRequestForRouting _request;
        StubHttpResponseForRouting _response;
     
        public StubHttpContextForRouting(string appPath = "/", string requestUrl = "~/") {
            _request = new StubHttpRequestForRouting(appPath, requestUrl);
            _response = new StubHttpResponseForRouting();
        }
     
        public override HttpRequestBase Request {
            get { return _request; }
        }
     
        public override HttpResponseBase Response {
            get { return _response; }
        }
    }
     
    public class StubHttpRequestForRouting : HttpRequestBase {
        string _appPath;
        string _requestUrl;
     
        public StubHttpRequestForRouting(string appPath, string requestUrl) {
            _appPath = appPath;
            _requestUrl = requestUrl;
        }
     
        public override string ApplicationPath {
            get { return _appPath; }
        }
     
        public override string AppRelativeCurrentExecutionFilePath {
            get { return _requestUrl; }
        }
     
        public override string PathInfo {
            get { return ""; }
        }
    }
     
    public class StubHttpResponseForRouting : HttpResponseBase {
        public override string ApplyAppPathModifier(string virtualPath) {
            return virtualPath;
        }
    }
