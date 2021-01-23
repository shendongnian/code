    void Main() 
    {
        var container = BuildContainer();
        using (AsyncScopedLifestyle.BeginScope(container))
        {
            var service = container.GetInstance<MyRootType>();
            service.DoSomething();
        }
        container.Dispose();
    }
