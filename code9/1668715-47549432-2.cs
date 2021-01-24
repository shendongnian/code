    bool isProcessing = false;
    object processingSync = new object();
    //...
    void ProcessQueue() 
    {
        bool shouldContinue;
        do
        {
            object item; //Set thhis to the right type
            lock (processingSync)
            {
                //Note: you wouldn't actually need a concurrent queue here,
                //since you are locking during enqueue and dequeue
                shouldContinue = messageQueue.TryDequeue(out item);
                if (!shouldContinue)
                {
                    isProcessing = false;
                }
            }
            //Process item
        }
        while (shouldContinue);
    }
    //When you enqueue your items...
    lock (processingSync)
    {
        messageQueue.Enqueue(item);
        if (!isProcessing)
        {
            Task.Run(ProcessQueue);
            isProcessing = true;
        }
    }
