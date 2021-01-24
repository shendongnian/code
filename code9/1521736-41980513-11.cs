    internal sealed class WebApiService : StatelessService
    {
		public TinyIoCContainer Container { get; private set; }
		public WebApiService(StatelessServiceContext context)
		    : base(context)
	    {
			Container = new TinyIoCContainer();
		    Container.Register<StatelessServiceContext>(context);
	    }
		protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext => new OwinCommunicationListener(appBuilder => Startup.ConfigureApp(appBuilder, Container), serviceContext, ServiceEventSource.Current, "ServiceEndpoint"))
            };
        }
    }
