    public static class UrlHelperExtensions
        {
            /// <summary>
            /// Get current URL with substituted values while preserving query string
            /// </summary>
            /// <param name="helper"></param>
            /// <param name="substitutes">Query string parameters or route data paremers. E.g. new { action="Index", sort = "asc"}</param>
            /// <returns></returns>
            public static string Current(this IUrlHelper helper, object substitutes)
            {
                RouteValueDictionary routeData = new RouteValueDictionary(helper.ActionContext.RouteData.Values);
                IQueryCollection queryString = helper.ActionContext.HttpContext.Request.Query;
    
                //add query string parameters to the route data
                foreach (var param in queryString)
                {
                    if (!string.IsNullOrEmpty(queryString[param.Key]))
                    {
                        //rd[param.Key] = qs[param.Value]; // does not assign the values!
                        routeData.Add(param.Key, param.Value);
                    }
                }
    
                // override parameters we're changing in the route data
                //The unmatched parameters will be added as query string.
                foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(substitutes.GetType()))
                {
                    var value = property.GetValue(substitutes);
                    if (string.IsNullOrEmpty(value.ToString()))
                    {
                        routeData.Remove(property.Name);
                    }
                    else
                    {
                        routeData[property.Name] = value;
                    }
                }
    
                string url = helper.RouteUrl(routeData);
                return url;
            }
        }
