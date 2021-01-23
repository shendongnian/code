    void Main() {
        var container = BuildContainer();
        using (container.BeginLifetimeScope())
        {
            var service = container.GetInstance<MyRootType>();
            service.DoSomething();
        }
        container.Dispose();
    }
