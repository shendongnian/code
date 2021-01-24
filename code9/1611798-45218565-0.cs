            string baseAddress = "http://" + Environment.MachineName;
    
            ServiceHost host = new ServiceHost(typeof(TestService), new Uri(baseAddress));
    
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ITestService), new WebHttpBinding(), "");
    
            endpoint.Behaviors.Add(new WebHttpBehavior());
    
            ServiceDebugBehavior debugBehavior = host.Description.Behaviors.Find<ServiceDebugBehavior>();
    
            debugBehavior.HttpHelpPageEnabled = false;
    
            debugBehavior.HttpsHelpPageEnabled = false;
    
            host.Open();
