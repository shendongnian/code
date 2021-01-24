    var assemblies = BuildManager
      .GetReferencedAssemblies()
      .Cast<Assembly>();
    foreach(var assembly in assemblies)
    {
      builder.RegisterAssemblyModules(assembly);
    }
    
