    var container = new UnityContainer();
    container.RegisterType<IWorker, Worker>();
    container.RegisterType<List<IWorker>>(new InjectionFactory(c =>
    {
        var workers = new List<IWorker>();
        for (var i = 0; i < 5; i++)
        {
            workers.Add(c.Resolve<IWorker>());
        }
        return workers;
    }));
    var service = container.Resolve<ServiceManagement>();
