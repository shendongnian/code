    class Program
    {
        static void Main()
        {
            var baseAddress = new Uri("http://localhost:8080/ProtoBuf");
    
            using (var serviceHost = new ServiceHost(typeof(ProtoBufService), baseAddress))
            {
                var endpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(IProtoBufService)),
                    new NetHttpBinding(),
                    new EndpointAddress(baseAddress));
    
                endpoint.EndpointBehaviors.Add(new ProtoEndpointBehavior());
                serviceHost.AddServiceEndpoint(endpoint);
                    
                serviceHost.Open();
                Console.ReadKey();
            }
        }
    }
