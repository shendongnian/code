    TaskCompletionSource<bool> _result;
    //main thread
    private void Main()
    {
    
        //some Code
        serialPort.Write("something");
        _result = new TaskCompletionSource<bool>();
        // Normally, one should "await" a Task. But in the Main() method, which
        // cannot be "async", we have to just wait synchronously.
        Task completed = Task.WhenAny(_result.Task,
            Task.Delay(TimeSpan.FromSeconds(10)).Result;
        // Don't check "_result.Result" unless the task has completed,
        // because otherwise the thread will block. If it is completed,
        // check "_result.Result" as the equivalent to examining the "status"
        // variable in the previous code example.
        while(!_result.IsCompleted || !_result.Result)
        {
            // do something else
        }
    }
    public void OndataReceived(object sender, EventArg arg)
    {
        //Function that recieve the data
        Receive();
    
        //change status to true
        _result.SetResult(true);
    
        return;
    }
