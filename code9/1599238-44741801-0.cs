    app.Use((context, next) =>
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var route = context.GetRouteData();
            if (route.Values["controller"].ToString() == "ANYCONTROLLER" &&
                route.Values["action"].ToString() == "ANYMETHOD")
            {
                context.Request.Path = "/CONTROLLER2/METHOD2";
            }
        }
    
        return next();
    });
