    public void ConfigureServices(IServiceCollection services)
    {
        var myAssembly = LoadAssembly();
        // find first interface
        var firstInterfaceType = myAssembly.DefinedTypes.FirstOrDefault(t => t.IsInterface).GetType();
        // find it's implementation
        var firstInterfaceImplementationType = myAssembly.DefinedTypes.Where(t => t.ImplementedInterfaces.Contains(firstInterfaceType)).GetType();
        // get general method info
        MethodInfo method = typeof(IServiceCollection).GetMethod("AddTransient");
        // provide types to generic method
        MethodInfo generic = method.MakeGenericMethod(firstInterfaceType, firstInterfaceImplementationType);
        // register your types
        generic.Invoke(services, null);
    }
