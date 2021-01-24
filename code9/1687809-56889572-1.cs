    private const string _topicName = "factfinder_topic";
    private const string _subscriptionName = "subs1";
    [FunctionName("FetchDataFromSubscription")]
    public static void Run([ServiceBusTrigger(_topicName, _subscriptionName, Connection = "ServiceBusConnectionString")] string mySbMsg, ILogger log) {
    	log.LogInformation($ "C# ServiceBus topic trigger function processed message: {mySbMsg}");
    }
