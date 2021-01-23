    // Let's say your factory is like this, where the cache
    // is stored in the instance, like a hash table. Adjust
    // your code as necessary.
    builder.RegisterType<MyCachingFactory>()
      .As<IFactory>()
      .SingleInstance();
    // Register a lambda that looks at the inbound set
    // of parameters and uses the registered factory
    // to resolve.
    builder.Register((c, p) =>
    {
      var name = p.Named<string>("Name");
      var factory = c.Resolve<IFactory>();
      return factory.GetInstanceByName(name);
    }).As<IProcessObject>();
