    try
    {   
    	await managementClient.GetTopicAsync(topicName);
    }
    catch (MessagingEntityNotFoundException)
    {   
    	await managementClient.CreateTopicAsync(new TopicDescription(topicName) { EnablePartitioning = true });
    }
    
    try
    {
    	await managementClient.GetQueueAsync(queueName);
    }
    catch (MessagingEntityNotFoundException)
    {
    	await managementClient.CreateQueueAsync(new QueueDescription(queueName) { EnablePartitioning = true });
    }
