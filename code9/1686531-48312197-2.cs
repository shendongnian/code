    public override void InitializeNewDomain(AppDomainSetup appDomainInfo)
    {
        // ...
        AppDomain.CurrentDomain.AssemblyResolve += 
            new ResolveEventHandler(MyCustomAssemblyResolver);
    }
    static Assembly MyCustomAssemblyResolver(object sender, ResolveEventArgs args) 
    {
        // Resolve how to find the requested Assembly using args.Name
        // Assembly.LoadFrom() would be a good way, as soon you found 
        // some matching Assembly manifest or DLL whereever you like to look up for it
    }
