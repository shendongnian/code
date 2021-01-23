    static EndpointAddress FindCalculatorServiceAddress()
    {
        // Create DiscoveryClient
        DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
    
        // Find ICalculatorService endpoints            
        FindResponse findResponse = discoveryClient.Find(new FindCriteria(typeof(IFooService)));
        if (findResponse.Endpoints.Count > 0)
        {
            return findResponse.Endpoints[0].Address;
        }
        else
        {
            return null;
        }
    }
