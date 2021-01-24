    while (threadProcessQueueExist)
    {
        int recordCountNew = concurrentQueue.Count();
        if (recordCountNew != 0)
        {
            if (isOrderBookUpdated)
            {
                ProcessQueueMessages();
            }
        }
    }
