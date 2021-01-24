    interface IServiceA
    {
        void Foo();
    }
    interface IServiceB
    {
        void Bar();
    }
    class ServiceA : IServiceA
    {
        public void Foo() { do something ; }
    }
    class ServiceB : IServiceB
    {
        public void Bar() { do something else; }
    }
    interface IProgram
    {
        void Execute();
    }
    class Program : IProgram
    {
        private readonly IServiceA _serviceA;
        private readonly IServiceB _serviceB;
        
        public Program(IServiceA serviceA, IServiceB serviceB)
        {
            _serviceA = serviceA;  //Injected dependency
            _serviceB = serviceB;  //Injected dependency
        }
        public void Execute()
        {
            _serviceA.Foo();
            _serviceB.Bar();
        }
    }
    void Main()
    {
        //Composition root
        var container = new UnityContainer();
        container.RegisterType<IServiceA, ServiceA>();
        container.RegisterType<IServiceB, ServiceB>();
        container.RegisterType<IProgram, Program>();
       
        //The one and only one entry point for Program
        container.Resolve<IProgram>().Execute();
    }
