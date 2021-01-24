    var types = typeof(WidgetContainer).Assembly.GetTypes().Where(t => t.GetInterfaces().Any());
    foreach(var type in types)
    {
        var interfaces = type.GetInterfaces();
        foreach(var i in interfaces)
        {
            performCheck(type, i);
        }
    }
