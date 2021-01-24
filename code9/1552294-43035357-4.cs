    string connectionString = "<Secret>"
    var namespaceManager =
        NamespaceManager.CreateFromConnectionString(connectionString);
    
    if (!namespaceManager.SubscriptionExists("TestTopic", "Inventory"))
    {
        namespaceManager.CreateSubscription("TestTopic", "Inventory");
    }
