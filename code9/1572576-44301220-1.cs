    var token = "";
    var tokenCred = new Microsoft.Azure.TokenCloudCredentials(token);
    var subscriptionClient = new SubscriptionClient(tokenCred);
    foreach (var subscription in subscriptionClient.Subscriptions.List())
    {
        Console.WriteLine(subscription.SubscriptionName);
    }
