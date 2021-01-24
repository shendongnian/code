    var host = new ServiceHost(typeof(FileService));
    
    host.AddServiceEndpoint(typeof(IFileService),
        new WebHttpBinding { TransferMode = TransferMode.StreamedRequest }, "http://localhost:8080")
        .EndpointBehaviors.Add(new WebHttpBehavior());
    
    host.Open();
    
    Console.WriteLine("The host is opened. Press ENTER to exit...");
    Console.ReadLine();
    
    host.Close();
