    private static ServiceClient;
    private static string connectionString = "{iot hub connection string}";
    
    public static void Main()
    {
        Console.WriteLine("Send Cloud-to-Device message\n");
        serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
    
        ReceiveFeedbackAsync();
    
        Console.WriteLine("Press any key to send a C2D message.");
        Console.ReadLine();
        SendCloudToDeviceMessageAsync().Wait();
        Console.ReadLine();
    }
    
    private async static Task SendCloudToDeviceMessageAsync()
    {
        var commandMessage = new Message(Encoding.ASCII.GetBytes("Cloud to device message."));
        commandMessage.Ack = DeliveryAcknowledgement.Full;
        await serviceClient.SendAsync("myFirstDevice", commandMessage);
    }
    
    private async static void ReceiveFeedbackAsync()
    {
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
    }
