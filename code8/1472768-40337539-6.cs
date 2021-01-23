    public static void CreateQueueMessage([ServiceBusTrigger("myqueue")] string message, [ServiceBus("queue2")] out string outputQueueMessage)
    {
        outputQueueMessage = message.ToUpper();
        //Console.WriteLine(message);
    }
