    container.RegisterConditionalInstance<IBlobAccessClient>(
        new BlobAccessClient(srcConnectionString),
        c => c.Consumer.Target.Parameter.Name.Contains("src"));
    container.RegisterConditionalInstance<IBlobAccessClient>(
        new BlobAccessClient(destConnectionString),
        c => c.Consumer.Target.Parameter.Name.Contains("dest"));
