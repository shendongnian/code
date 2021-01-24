    Uri baseAddress = new Uri(string.Format("http://{0}:8000/discovery/scenarios/calculatorservice/{1}/",  
            System.Net.Dns.GetHostName(), Guid.NewGuid().ToString()));  
      
    // Create a ServiceHost for the CalculatorService type.  
    using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))  
    {  
        // add calculator endpoint  
        serviceHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), string.Empty);  
      
        // ** DISCOVERY ** //  
        // make the service discoverable by adding the discovery behavior  
        ServiceDiscoveryBehavior discoveryBehavior = new ServiceDiscoveryBehavior();  
        serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());  
      
        // send announcements on UDP multicast transport  
        discoveryBehavior.AnnouncementEndpoints.Add(  
          new UdpAnnouncementEndpoint());  
      
        // ** DISCOVERY ** //  
        // add the discovery endpoint that specifies where to publish the services  
        serviceHost.Description.Endpoints.Add(new UdpDiscoveryEndpoint());  
      
        // Open the ServiceHost to create listeners and start listening for messages.  
        serviceHost.Open();  
      
        // The service can now be accessed.  
        Console.WriteLine("Press <ENTER> to terminate service.");  
        Console.ReadLine();  
    }  
