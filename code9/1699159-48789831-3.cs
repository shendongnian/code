    public async Task RouteAsync(RouteContext context)
    {
        var requestPath = context.HttpContext.Request.Path.Value;
        if (!string.IsNullOrEmpty(requestPath) && requestPath[0] == '/')
        {
            // Trim the leading slash
            requestPath = requestPath.Substring(1);
        }
        // Get the page id that matches.
        TPrimaryKey id;
        //If this returns false, that means the URI did not match
        if (!GetPageList().TryGetValue(requestPath, out id))
        {
            return;
        }
        //Invoke MVC controller/action
        var oldRouteData = context.RouteData;
        var newRouteData = new RouteData(oldRouteData);
        newRouteData.Routers.Add(_target);
        newRouteData.Values["controller"] = _controller;
        newRouteData.Values["action"] = _action;
        // This will be the primary key of the database row.
        // It might be an integer or a GUID.
        newRouteData.Values["id"] = id;
        try
        {
            context.RouteData = newRouteData;
            await _target.RouteAsync(context);
        }
        finally
        {
            // Restore the original values to prevent polluting the route data.
            if (!context.IsHandled)
            {
                context.RouteData = oldRouteData;
            }
        }
    }
