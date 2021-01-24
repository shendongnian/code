    using (var container = new UnityContainer())
    {
        var extension = new MyUnityExtension();
        container.AddExtension(extension);
        var resolved = container.Resolve<IMyType>();
        Assert.IsNotNull(resolved);
    }
