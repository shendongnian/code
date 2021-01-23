    public sealed class UrlRouteHandler : IRouteHandler
    {
         public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var url = requestContext.HttpContext.Request.Url.ToString();
            var routeData = requestContext.RouteData.Values;
            // manage your rules here!
    
            routeData["controller"] = "YourController";
            routeData["action"] = "YourAction";
            
            return new MvcHandler(requestContext);
        }
    }
