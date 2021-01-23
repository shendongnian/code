    public override void StartSubscribing(Action<QueueItem> messageHandlerMethod)
    {
        // do something to get/create a QueueItem
        QueueItem item = SomeMagic();
    
       // pass it back to the passed in delegate
       messageHandlerMethod(item);   
    }
