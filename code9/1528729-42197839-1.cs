    private BlockingCollection<DataRecievedEnqeueInfo> mReceivingThreadQueue = new BlockingCollection<DataRecievedEnqeueInfo>();
    private BlockingCollection<DataSendEnqeueInfo> mSendingThreadQueue = new BlockingCollection<DataSendEnqeueInfo>();
    
    public void Stop()
    {
    	// No need for mIsRunning. Makes the enumerables in the GetConsumingEnumerable() calls
    	// below to complete.
    	mReceivingThreadQueue.CompleteAdding();
    	mSendingThreadQueue.CompleteAdding();
    }
    
    private void ReceivingThread()
    {
    	foreach (DataRecievedEnqeueInfo item in mReceivingThreadQueue.GetConsumingEnumerable())
    	{
    		ProcessReceivingItem(item);
    	}
    }
    
    private void SendingThread()
    {
    	foreach (DataSendEnqeueInfo item in mSendingThreadQueue.GetConsumingEnumerable())
    	{
    		ProcessSendingItem(item);
    	}
    }
    
    internal void EnqueueRecevingData(DataRecievedEnqeueInfo info)
    {
    	// You can also use TryAdd() if there is a possibility that you
    	// can add items after you have stopped. Otherwise, this can throw an
        // an exception after CompleteAdding() has been called.
    	mReceivingThreadQueue.Add(info);
    }
    
    public void EnqueueSend(DataSendEnqeueInfo info)
    {
    	mSendingThreadQueue.Add(info);
    }
