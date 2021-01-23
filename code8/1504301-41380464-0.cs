    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    ConcurrentQueue<string> MessageQueue;
    ManualResetEventSlim queRefilled = new ManualResetEventSlim(false);
    bool writerStopper;
    Task messageWriter;
    private void MessageDispatcher() //this is going to be the writing thread
	{
		while (!writerStopper)
		{
			if(MessageQueue.Count ==0)
			{
                //loop every 200 seconds to check the writerStopper
				if (!queRefilled.Wait(200)) //wait until we know that a message has been added, this was done to minimize latency.
					continue;
				queRefilled.Reset();
				continue;
			}
			string message;
			if (MessageQueue.TryDequeue(out message))
				yourWriteMethod(message); //here you can call your existing writer
		}
	}
    //call this to add a message to the screen
    public void QueueToScreen(string message)
    {
        MessageQueue.Enqueue(message);
        queRefilled.Set(); //set the flag so that the writer knows that there are messages
    }
    public void start()
    {
        MessageQueue = new ConcurrentQueue<string>();
        writerStopper = false;
    	messageWriter = new Task(MessageDispatcher);
    	messageWriter.Start();
    }
        public void stop() 
    {
       writerStopper = true;
       MessageQueue = null;
    }
