    public static bool IsRouteValueDefined(string controller, string action)
    {
        var mvcHanlder = (MvcHandler)HttpContext.Current.Handler;
        var routeValues = mvcHanlder.RequestContext.RouteData.Values;
        var containsRouteKey = routeValues.ContainsKey(routeKey);
        if (routeValue == null)
            return containsRouteKey;
        return containsRouteKey &&
               routeValues["controller"].ToString().Equals(controller, StringComparison.InvariantCultureIgnoreCase) &&
               routeValues["action"].ToString().Equals(action, StringComparison.InvariantCultureIgnoreCase);
    }
