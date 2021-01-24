    private const string _topicName = "factfinder_topic";
    private const string _subscriptionName = "subs1";
    private static ITopicClient _topicClient;
    private static ILogger _logger;
    [FunctionName("SendDataToSubscription")]
    public static void Run([ServiceBusTrigger(_topicName, _subscriptionName, Connection = "ServiceBusConnectionString")] string mySbMsg, ILogger log) {
    	_logger = log;
    	PrepareSend().GetAwaiter().GetResult();
    	_logger.LogInformation($ "C# ServiceBus topic trigger function processed message: {mySbMsg}");
    }
    
