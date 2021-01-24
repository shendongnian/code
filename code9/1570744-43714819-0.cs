       string connectionString = "Sb-connection-string";
    
       var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
    
       if (!namespaceManager.TopicExists("TestTopic"))
       {
           namespaceManager.CreateTopic("TestTopic");
       }
       
       Thread.Sleep(2*1000);
