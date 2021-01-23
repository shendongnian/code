    container.Register(
        Classes.FromAssemblyContaining(typeof(IFoo<>))
            .InSameNamespaceAs(typeof(IFoo<>))
            .WithServiceAllInterfaces()
            .LifeStyleHybridPerWebRequestTransient()
            .Configure(r => r.DynamicParameters((k, d) =>
            {
                var subDependency = k.Resolve<ISubDependency>(d);
                d.Add("subDepedency", subDependency); 
            })));
