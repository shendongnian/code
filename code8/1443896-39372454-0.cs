    var assemblies = CosturaAssemblyExtractor.Extract(AppDomain.CurrentDomain, Assembly.GetExecutingAssembly(), "My.AssemblyName");
    foreach (var assembly in assemblies)
    {
        catalog.Catalogs.Add(new AssemblyCatalog(assembly.Value));
    }
    container = new CompositionContainer(catalog);
