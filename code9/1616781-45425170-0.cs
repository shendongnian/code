    public static void PostToAzureQueue(AlertNotification alertNotification, CloudQueueClient client)
    {
        var queue = client.GetQueueReference("activealertsqueue");
        queue.AddMessage(new CloudQueueMessage(alertNotification.Serialize()));
    }
