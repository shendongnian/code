    private async Task<bool> DoProduce(Topic topic, object someObject)
    {
        try
        {
            var report = await topic.Produce(someObject);
            _logger.LogDebug("Producer Succeed");
            return true;
        }
        catch (Exception ex)
        {
            HandleError(ex);
            return false;
        }
    }
    public Task<bool> ProduceAsync(object someObject)
    {
        var producer = new Producer(_kafkaOptions.Uri);
        Topic topic = null;
        try
        {
            topic = producer.Topic(_kafkaOptions.Topic, topicConfig);
        }
        finally
        {
            producer.Dispose();                
        }
        var task = DoProduce(topic, someObject);
        task.ContinueWith(t =>
        {
            topic.Dispose();
            producer.Dispose();
        }, TaskScheduler.Default);
        return task;
    }
