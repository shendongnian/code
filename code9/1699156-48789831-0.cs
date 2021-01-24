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
        var routeData = context.RouteData;
        routeData.Values["controller"] = _controller;
        routeData.Values["action"] = _action;
        // This will be the primary key of the database row.
        // It might be an integer or a GUID.
        routeData.Values["id"] = id;
        await _target.RouteAsync(context);
    }
