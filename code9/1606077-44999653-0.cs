    var asmNames = DependencyContext.Default.GetDefaultAssemblyNames();
    var type = typeof(BaseViewComponent);
    var allTypes = asmNames.Select(Assembly.Load)
        .SelectMany(t => t.GetTypes())
        .Where(p => p.GetTypeInfo().IsSubclassOf(type));
