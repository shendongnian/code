    public uint GetMessageCount(string queueName)
    {
        using (IConnection connection = factory.CreateConnection())
        using (IModel channel = connection.CreateModel())
        {
            return channel.MessageCount(queueName);
        }
    }
