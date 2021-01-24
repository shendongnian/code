    class StandardConnectionFactory : IConnectionFactory
    {
        private readonly IContainer iocContainer;
        public StandardConnectionFactory(IContainer iocContainer) 
        {
            this.iocContainer = iocContainer;
        }
        public IConnection Create(string param1, int param2, ...)
        {
             if (...) return iocContainer.Resolve<IFancySshConnection>();
             else return iocContainer.Resolve<IAnotherConnection>();
        }
    } 
