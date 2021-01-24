    internal sealed class MyStatelessService: StatelessService, ICalculatorService
    {
        public MyStatelessService(StatelessServiceContext serviceContext) : base(serviceContext)
        {
    
        }
    
        public Task<int> Add(int a, int b)
        {
            return Task.FromResult<int>(a + b);
        }
    
        public Task<int> Subtract(int a, int b)
        {
            return Task.FromResult<int>(a - b);
        }
    
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[] { new ServiceInstanceListener(context => this.CreateServiceRemotingListener(context)) };
        }
    }
