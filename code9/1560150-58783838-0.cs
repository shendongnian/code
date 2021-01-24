`
    services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
      .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
      .Where(t => typeof(IController).IsAssignableFrom(t) 
       || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));
`
