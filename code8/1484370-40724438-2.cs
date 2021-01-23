    var serviceHost = new ServiceHost(mock, new[] { baseAddress });
 
    serviceHost.Description.Behaviors
        .Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
    serviceHost.Description.Behaviors
        .Find<ServiceBehaviorAttribute>().InstanceContextMode = InstanceContextMode.Single;
 
    serviceHost.AddServiceEndpoint(typeof(TMock), new BasicHttpBinding(), endpointAddress);
 
