    var Uri = new Uri("net.tcp://myaddress:4322/MyService");
    var MetadataUri = new Uri("http://myaddress:8000/MyService");
    var MyServiceHost = new ServiceHost(typeof(MyService), Uri, MetadataUri);
    var serviceBehavior = MyServiceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
    if (serviceBehavior == null)
    {
        serviceBehavior = new ServiceMetadataBehavior();
        MyServiceHost.Description.Behaviors.Add(serviceBehavior);
    }
    serviceBehavior.HttpGetEnabled = true;
    serviceBehavior.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
    MyServiceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
    var binding = new NetTcpBinding();
    MyServiceHost.AddServiceEndpoint(typeof(IImageExchangeService), binding, "image");
