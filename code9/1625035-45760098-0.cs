    this.Container.RegisterType<List<IWorker>>(new InjectionFactory(c =>
            {
                var workers = new List<IWorker>();
                for (int i = 0; i < N; i++)
                {
                    workers.Add(c.Resolve<IWorker>());
                }
                return workers;
            }));
