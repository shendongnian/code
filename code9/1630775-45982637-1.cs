    var container = new UnityContainer();
    
    container
        .RegisterType<IExampleService, ExampleService>()
        .RegisterType<ExampleService>(
            new InjectionConstructor(someValue));
    
    var host = new ServiceHost(typeof(ExampleService));
    
    foreach (var endpoint in host.Description.Endpoints)
    	endpoint.EndpointBehaviors.Add(new UnityEndpointBehavior(container));
    
    host.Open();
    
    // ...
    class UnityEndpointBehavior : IEndpointBehavior
    {
        private readonly IUnityContainer container;
    
        public UnityEndpointBehavior(IUnityContainer container)
        {
            this.container = container;
        }
    
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
    
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }
    
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.InstanceProvider =
                new UnityInstanceProvider(container, endpoint.Contract.ContractType);
        }
    
        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
    
    class UnityInstanceProvider : IInstanceProvider
    {
        private readonly IUnityContainer container;
        private readonly Type contractType;
    
        public UnityInstanceProvider(IUnityContainer container, Type contractType)
        {
            this.container = container;
            this.contractType = contractType;
        }
    
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }
    
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return container.Resolve(contractType);
        }
    
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            container.Teardown(instance);
        }
    }
