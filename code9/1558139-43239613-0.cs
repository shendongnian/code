    private static void OnApplicationAuthenticateRequest(object sender, EventArgs e) 
    {
        var context = ((HttpApplication)sender).Context;
        var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(context)); 
        var controllerName = routeData.Values["controller"];
        ...
    }
