    var types = Assembly.GetExecutingAssembly()
    	.GetTypes()
    	.Where(t => t.Namespace == "Your.Custom.Namespace");
    foreach (var type in types)
    {
    	services.RegisterTransient(type);
    }
