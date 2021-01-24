    host = new WebServiceHost(typeof(Service), new Uri("http://0.0.0.0:9000/"));
    try
    {
        var binding = new WebHttpBinding();
        binding.MaxReceivedMessageSize = Int32.MaxValue;
        binding.MaxBufferSize = Int32.MaxValue;
        ep = host.AddServiceEndpoint(typeof(IService), binding, "");
        host.Open();
        cf = new ChannelFactory<IService>(binding, "http://localhost:9000");
        cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
        Log("Webservice started an listening on " + "http://0.0.0.0:9000/");
    }    
