    //get collectors
    var types = typeof(CollectorA).Assembly
        .GetTypes()
        .Where(t => typeof(ICollector).IsAssignableFrom(t));
    //add to service
    foreach(var item in types)
    {
        serviceCollection.AddTransient(typeof(ICollector), item);
    } 
