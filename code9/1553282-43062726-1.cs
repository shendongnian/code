    var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
	var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
	var checkTask = namespaceManager.SubscriptionExistsAsync("myTopic", $"mySubscription");
	var delayTask = Task.Delay(TimeSpan.FromSeconds(20));
	var finishedTask = await Task.WhenAny(checkTask, delayTask).ConfigureAwait(false);
	if (finishedTask == delayTask)
		Console.WriteLine("Couldn't get result after 20 seconds");
	else
		Console.WriteLine($"Subscription was found: {checkTask.Result}");
