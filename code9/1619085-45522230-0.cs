    class DispatchingSubFactoryProxy : ISubFactory
    {
        private readonly ISubFactory aFactory;
        private readonly ISubFactory bFactory;
        
        public DispatchingSubFactoryProxy(
            ISubFactory aFactory, ISubFactory bFactory)
        {
            this.aFactory = aFactory;
            this.bFactory = bFactory;
        }
        public Model PremareSubModel(Customer c) => GetFactory(c).PremareSubModel(c);
        ISubFactory GetFactory(Customer c) => c.aService ? aFactory : bFactory;
    }
