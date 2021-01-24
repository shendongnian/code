    AutoResetEvent waitHandle = new AutoResetEvent(false);
    while (true)
    {
        waitHandle.WaitOne();
        while (!messageQueue.IsEmpty)
        {
            //Post to server
        }
    }
    //When you enqueue your items...
    messageQueue.Enqueue(item);
    waitHandle.Set();
