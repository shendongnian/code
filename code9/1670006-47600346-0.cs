    namespace DL.SO.Project.Framework.Mvc.Extensions
    {
        public static class UrlHelperExtensions
        {
            public static string Current(this IUrlHelper url, object routeValues)
            {
                // Get current route data
                var currentRouteData = url.ActionContext.RouteData.Values;
    
                // Get current route query string and add them back to the new route
                // so that I can preserve them.
                // For example, if the user applies filters, the url should have
                // query strings '?foo1=bar1&foo2=bar2'. When you construct the
                // pagination links, you don't want to take away those query 
                // strings.
    
                var currentQuery = url.ActionContext.HttpContext.Request.Query;
                foreach (var param in currentQuery)
                {
                    currentRouteData[param.Key] = param.Value;
                }
    
                // Convert new route values to a dictionary
                var newRouteData = new RouteValueDictionary(routeValues);
    
                // Merge new route data
                foreach (var item in newRouteData)
                {
                    currentRouteData[item.Key] = item.Value;
                }
    
                return url.RouteUrl(currentRouteData);
            }
        }
    }
