    {
        private static readonly serviceA = new ServiceA();
        private static readonly serviceB = new ServiceB();
        
        public IServiceA ServiceA { get { return serviceA; } }
        public IServiceB ServiceB { get { return serviceB; } }
    }
