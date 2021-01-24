    if (configSwitch)
    {
        routes.MapRoute(
            "Custom",
            "api/data/{id}",
             new { 
                     controller = "MyController", 
                     action = "PostV1"
                 }
        );
    }
    else
    {
        routes.MapRoute(
            "Custom",
            "api/data/{id}",
             new { 
                     controller = "MyController", 
                     action = "PostV2"  //Notice the version difference
                 }
        );
    }
