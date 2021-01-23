    static void Main(string[] args)
    {
        var container = new Container();
        // GetTypesToRegister can do the assembly scanning for you.
        IEnumerable<Type> types = container.GetTypesToRegister(typeof(IFoo<>), 
            new[] { Assembly.GetExecutingAssembly() });
        // Here we create a list of Registration instance once.
        Registration[] regs = (
            from type in types
            select Lifestyle.Singleton.CreateRegistration(type, container))
            .ToArray();
        // Here we register the registrations as one-to-one mapping.
        foreach (var reg in regs)
        {
            Type closedGenericFoo = reg.ImplementationType.GetInterfaces()
                .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IFoo<>))
                .Single();
            container.AddRegistration(closedGenericFoo, reg);
        }
        // Here we make a one-to-many mapping between IFoo and the registrations.
        container.RegisterCollection<IFoo>(regs);
        container.Verify();
        ...
    }
