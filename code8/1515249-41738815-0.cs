    string serviceAddress = "net.tcp://localhost:8088/FooBarService";
    ServiceHost selfServiceHost = new ServiceHost(typeof(FooBarService));            
    // The endpoints need to share this binding.
    var binding = new NetTcpBinding();
    selfServiceHost.AddServiceEndpoint(typeof(IFooService), binding, serviceAddress);
    selfServiceHost.AddServiceEndpoint(typeof(IBarService), binding, serviceAddress);
    // Add ServiceDiscoveryBehavior
    selfServiceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
    // Add a UdpDiscoveryEndpoint
    selfServiceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());
