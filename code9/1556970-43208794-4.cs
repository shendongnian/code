    ContainerBuilder builder = new ContainerBuilder();
    builder.Register(c => c.Resolve<ILifetimeScope>()
                .BeginLifetimeScope("A", _ =>
                {
                    _.RegisterType<FooA>().As<IFoo>();
                }))
            .Named<ILifetimeScope>("A");
    builder.Register(c => c.Resolve<ILifetimeScope>()
                .BeginLifetimeScope("B", _ =>
                {
                    _.RegisterType<FooB>().As<IFoo>();
                }))
            .Named<ILifetimeScope>("B");
    // build the root of all profile
    IContainer container = builder.Build();
    // get the profile lifetimescope 
    ILifetimeScope profileScope = container.ResolveNamed<ILifetimeScope>("B");
    // use a working lifetimescope from your profile
    using (ILifetimeScope workingScope = profileScope.BeginLifetimeScope())
    {
        IFoo foo = workingScope.Resolve<IFoo>();
        Console.WriteLine(foo.GetType());
    }
