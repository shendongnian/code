    var container = new UnityContainer();
    container.RegisterType<IWorker, Worker>();
    container.RegisterType<List<IWorker>>(typeof(ServiceManagement).Name,
        new InjectionFactory(c =>
        {
            var workers = new List<IWorker>();
            for (var i = 0; i < 5; i++)
            {
                workers.Add(c.Resolve<IWorker>());
            }
            return workers;
        }));
    container.RegisterType<List<IWorker>>(typeof(OrderManagement).Name,
        new InjectionFactory(c =>
        {
            var workers = new List<IWorker>();
            for (var i = 0; i < 20; i++)
            {
                workers.Add(c.Resolve<IWorker>());
            }
            return workers;
        }));
    container.RegisterType<ServiceManagement>(
        new InjectionFactory(c => new ServiceManagement(c.Resolve<List<IWorker>>(typeof(ServiceManagement).Name))));
    container.RegisterType<OrderManagement>(
        new InjectionFactory(c => new OrderManagement(c.Resolve<List<IWorker>>(typeof(OrderManagement).Name))));
    var service = container.Resolve<ServiceManagement>();
    var order = container.Resolve<OrderManagement>();
