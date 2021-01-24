csharp
QueueClient queueClient;
CancellationTokenSource cts = new CancellationTokenSource();
ActionBlock<Message> actionBlock;
async Task Main()
{
	// Define message processing pipeline
	actionBlock = new ActionBlock<Message>(ProcessMessagesAsync, new ExecutionDataflowBlockOptions
	{
		BoundedCapacity = 10,
		MaxDegreeOfParallelism = 10
	});
	
	queueClient = new QueueClient("Endpoint=sb:xxx, "test");
	RegisterOnMessageHandlerAndReceiveMessages(cts.Token);
	Console.WriteLine("Press [Enter] to stop processing messages");
	Console.ReadLine();
	
	// Signal the message handler to stop processing messages, step 1 of the flow
	cts.Cancel();
	
	// Signal the processing pipeline that no more message will come in,  step 1 of the flow
	actionBlock.Complete();
	
	// Wait for all messages to be done before closing the client, step 2 of the flow
	await actionBlock.Completion;
		
	await queueClient.CloseAsync(); // step 3 of the flow
	Console.ReadLine();
}
void RegisterOnMessageHandlerAndReceiveMessages(CancellationToken stoppingToken)
{
	// Configure the message handler options in terms of exception handling, number of concurrent messages to deliver, etc.
	var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
	{
		// Maximum number of concurrent calls to the callback ProcessMessagesAsync(), set to 1 for simplicity.
		// Set it according to how many messages the application wants to process in parallel.
		MaxConcurrentCalls = 10,
		// Indicates whether the message pump should automatically complete the messages after returning from user callback.
		// False below indicates the complete operation is handled by the user callback as in ProcessMessagesAsync().
		AutoComplete = false
	};
	// Register the function that processes messages.
	queueClient.RegisterMessageHandler(async (msg, token) =>
	{
		// When the stop signal is given, do not accept more messages for processing
		if(stoppingToken.IsCancellationRequested)
			return;
			
		await actionBlock.SendAsync(msg);
		
	}, messageHandlerOptions);
}
async Task ProcessMessagesAsync(Message message)
{
	Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
	// Process the message.
	await Task.Delay(5000);
	
	// Complete the message so that it is not received again.
	// This can be done only if the queue Client is created in ReceiveMode.PeekLock mode (which is the default).
	await queueClient.CompleteAsync(message.SystemProperties.LockToken);
	Console.WriteLine($"Completed message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
}
Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
{
	Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
	var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
	Console.WriteLine("Exception context for troubleshooting:");
	Console.WriteLine($"- Endpoint: {context.Endpoint}");
	Console.WriteLine($"- Entity Path: {context.EntityPath}");
	Console.WriteLine($"- Executing Action: {context.Action}");
	return Task.CompletedTask;
}
