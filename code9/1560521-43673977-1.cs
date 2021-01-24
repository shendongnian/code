    if (string.IsNullOrEmpty(location) 
        && cookie != null
        && !string.IsNullOrEmpty(cookie.Values["location"])
        && filterContext.ActionDescriptor.ActionName == "LandingPage"
        && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Home")
    {
        filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary
            {
                { "location", cookie.Values["location"]},
                { "controller", "Measurements" },
                { "action", "Index" }
            }
        );
    }
    else if (string.IsNullOrEmpty(location) 
        && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != "Home" 
        && !filterContext.IsChildAction)
    {
        filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary
            {
                { "controller", "Home" },
                { "action", "LandingPage" }
            }
    }
