    container.RegisterConditional(typeof(IBlobAccessClient),
        Lifestyle.Singleton.CreateRegistration(
            () => new BlobAccessClient(srcConnectionString), container),
        c => c.Consumer.Target.Parameter.Name.Contains("src"));
    container.RegisterConditional(typeof(IBlobAccessClient),
        Lifestyle.Singleton.CreateRegistration(
            () => new BlobAccessClient(destConnectionString), container),
        c => c.Consumer.Target.Parameter.Name.Contains("dest"));
