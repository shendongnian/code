            const int N = 5;
            UnityContainer container = new UnityContainer();
            container.RegisterType<IService, ServiceManagement>();
            for (int i = 0; i < N; i++)
            {
                container.RegisterType<IWorker, Worker>(i.ToString());
            }
            container.RegisterType<IList<IWorker>, IWorker[]>();
            var service = container.Resolve<IService>();
            Console.WriteLine("count:"+service.RefCount());
