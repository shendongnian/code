    internal class MyStatelessService : StatelessServiceBase
    {
        public MyStatelessService(StatelessServiceContext context)
            : base(context)
        {
        }
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            yield return new ServiceInstanceListener(context =>
                     this.CreateListener(context, new MyService(), "IMyService", new AuthenticationInspector()));
        }
    }
