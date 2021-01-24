            protected override DependencyObject CreateShell()
        {
            Container.AddNewExtension<Interception>();
            Container.RegisterType<jobsRepository>(new Interceptor<VirtualMethodInterceptor>()
                                         , new InterceptionBehavior<LogBehavior>());
            var jobsRepo = Container.Resolve<jobsRepository>();
            jobsRepo.GetJobs();
            return Container.Resolve<MainWindow>();
        }
