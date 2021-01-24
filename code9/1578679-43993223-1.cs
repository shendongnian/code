    RootContainer = new Container(scopeContext: new ThreadScopeContext());
    RootContainer.Register<IService, MyService>(Reuse.InCurrentScope);
    // in your thread
    using (RootContainer.OpenScope())
    {
        var service = RootContainer.Resolve<IService>();
        // use the service
    }
