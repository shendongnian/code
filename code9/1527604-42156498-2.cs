    public static void RegisterRoutes(RouteCollection routes)
    {
        // ... other routes
        string[] possibleValueSet1 = new[] { ... };
        string[] possibleValueSet2 = new[] { ... };
        for (int i = 0; i < possibleValueSet1.Length; ++i)
        {
            routes.MapRoute(
                name: "YourActionWithValueSet1_" + i.ToString(),
                url: "ControllerName/FirstAction/" + possibleValueSet1[i],
                defaults: new { controller = "ControllerName", action = "FirstAction", foo = possibleValueSet1[i] }
            );
        }
        for (int i = 0; i < possibleValueSet2.Length; ++i)
        {
            routes.MapRoute(
                name: "YourActionWithValueSet2_" + i.ToString(),
                url: "ControllerName/SecondAction/" + possibleValueSet2[i],
                defaults: new { controller = "ControllerName", action = "SecondAction", foo = possibleValueSet2[i] }
            );
        }
            
    }
