    public void CaptiveDependencyTest()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<ShortLived>()
            .SingleInstance();
        builder.RegisterType<LongLived>()
            .SingleInstance();
        var container = builder.Build();
        //using (var scope = container.BeginLifetimeScope(b => b.RegisterType<ShortLived>()))
        //{
            var longLived = container.Resolve<LongLived>();
            longLived.DoSomethingWithShortLived();
        //}
    }
