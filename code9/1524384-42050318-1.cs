    public WebApiService(StatefulServiceContext context)
        : base(context)
    {
        Container = new TinyIoCContainer();
        Container.Register<IReliableStateManagerReplica>(this.StateManager);
    }
