    static void Main(string[] args)
    {
        AppDomainSetup domaininfo = new AppDomainSetup();
        domaininfo.ApplicationBase = @"c:\testa\";
        Evidence adevidence = AppDomain.CurrentDomain.Evidence;
        AppDomain domain = AppDomain.CreateDomain("MyDomain", adevidence, domaininfo);
        AssemblyResolver resolver = new AssemblyResolver();
        domain.Assembly += resolver.Resolve;
        Type type = typeof(Proxy);
        var value = (Proxy)domain.CreateInstanceAndUnwrap(
            type.Assembly.FullName,
            type.FullName);
        var assembly = value.GetAssembly(args[0]);
        // AppDomain.Unload(domain);
    }
