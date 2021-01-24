        /// <summary>
        /// Get URL with substituted values while preserving query string.
        /// </summary>
        /// <param name="helper">The url helper object we are extending.</param>
        /// <param name="action">The action we want to direct to.</param>
        /// <param name="controller">The controller we want to direct to.</param>
        /// <param name="substitutes">Query string parameters or route data paremers. E.g. new { action="Index", sort = "asc"}</param>
        /// <returns>The route string.</returns>
        public static String ActionWithOriginalQueryString(this UrlHelper helper, String action, String controller, object substitutes)
        {            
            RouteValueDictionary routeData = new RouteValueDictionary(helper.RequestContext.RouteData.Values);
            NameValueCollection queryString = helper.RequestContext.HttpContext.Request.QueryString;
            //add query string parameters to the route data
            foreach (var param in queryString.AllKeys)
            {
                if (!string.IsNullOrEmpty(queryString[param]))
                {
                    //rd[param.Key] = qs[param.Value]; // does not assign the values!
                    routeData.Add(param, queryString[param]);
                }
            }
            // override parameters we're changing in the route data
            //The unmatched parameters will be added as query string.
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(substitutes.GetType()))
            {
                var value = property.GetValue(substitutes);
                if (string.IsNullOrEmpty(value?.ToString()))
                {
                    routeData.Remove(property.Name);
                }
                else
                {
                    routeData[property.Name] = value;
                }
            }
            //Set the controller and the action.
            routeData["controller"] = controller;
            routeData["action"] = action;
            //Return the route.
            return helper.RouteUrl(routeData);
        }
