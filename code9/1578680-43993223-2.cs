    RootContainer = new Container(); // without ambient scope context
    RootContainer.Register<IService, MyService>(Reuse.InCurrentScope);
    // in your thread
    using (var scopedContainer = RootContainer.OpenScope())
    {
        var service = scopedContainer.Resolve<IService>();
        // use the service
    }
