    public static void MapMvcRouteAttributes(RouteCollection routes)
    {
        IRouteHandler routeHandler = new System.Web.Mvc.MvcRouteHandler();
        Type[] addOnMvcControllers =
            AddOnManager.Default.AddOnAssemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(AddOnWebController).IsAssignableFrom(x) && x.Name.EndsWith("Controller"))
                .ToArray();
        foreach (Type controller in addOnMvcControllers)
        {
            string controllerName = controller.Name.Substring(0, controller.Name.Length - 10);
            System.Web.Mvc.RoutePrefixAttribute routePrefix = controller.GetCustomAttribute<System.Web.Mvc.RoutePrefixAttribute>();
            MethodInfo[] actionMethods = controller.GetMethods();
            string prefixUrl = routePrefix != null ? routePrefix.Prefix.TrimEnd('/') + "/" : string.Empty;
            foreach (MethodInfo method in actionMethods)
            {
                System.Web.Mvc.RouteAttribute route = method.GetCustomAttribute<System.Web.Mvc.RouteAttribute>();
                if (route != null)
                {
                    routes.Add(
                        new Route(
                            (prefixUrl + route.Template.TrimStart('/')).TrimEnd('/'),
                            new RouteValueDictionary { { "controller", controllerName }, { "action", method.Name } },
                            routeHandler));
                }
            }
        }
    }
