    public static async Task Run(
        [ServiceBusTrigger("topicname", "subname", AccessRights.Manage, Connection = "TopicConnection")]string message,
        TraceWriter log)
    {
        try
        {
            log.Info($"C# ServiceBus topic trigger function processed message: {message}");
            await PushToDb(message, log);
        }
        catch(Exception ex)
        {
            log.Info($"Exception found {ex.Message}");
        }
    }
