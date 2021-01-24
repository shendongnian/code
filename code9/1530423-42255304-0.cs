    routes.MapRoute(
        "MyCustomRoute",
        "Controller/{action}/{myEnum}",
        new { controller = "Controller", action = "MyMethod", myEnum = MyEnum.Pending }
    );
    routes.MapRoute(
        "Default",
        "{controller}/{action}/{id}",
        new { controller = "Home", action = "Index", id = UrlParameter.Optional }
     );
