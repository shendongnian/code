    KindOfSimpleFacade  
    {
        private static readonly _serviceA = new ServiceA();
        private static readonly _serviceB = new ServiceB();
        public IServiceA ServiceA { get { return ServiceA; } }
        public IServiceB ServiceB { get { return ServiceB; } }
    }
