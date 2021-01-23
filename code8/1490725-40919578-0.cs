    var serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
    var commandMessage = new Message(Encoding.ASCII.GetBytes("Cloud to device message."));
    commandMessage.Ack = DeliveryAcknowledgement.Full;
    await serviceClient.SendAsync("myFirstDevice", commandMessage);
    var feedbackReceiver = serviceClient.GetFeedbackReceiver();
    
    Console.WriteLine("\nReceiving c2d feedback from service");
    while (true)
    {
         var feedbackBatch = await feedbackReceiver.ReceiveAsync();
         if (feedbackBatch == null) continue;
    
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.WriteLine("Received feedback: {0}", string.Join(", ", feedbackBatch.Records.Select(f => f.StatusCode)));
         Console.ResetColor();
    
         await feedbackReceiver.CompleteAsync(feedbackBatch);
    }
