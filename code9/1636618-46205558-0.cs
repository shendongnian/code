    //in your console application
    using (var scope = Container.BeginLifetimeScope())
    {
        IServiceservice = scope.Resolve<IService>();
        service.Execute();
    }
    
    class SomeService : IService
    {
        readonly ISomeDependency _dependency;
    
        public SomeService(ISomeDependency dependency)
        {
            _dependency = dependency;
        }
    
        public void Execute()
        {
            _dependency.DoSomething();
        }
    }
    
    interface IService
    {
        void Execute();
    }
