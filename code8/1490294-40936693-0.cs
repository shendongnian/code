    /// field in your class
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    using (var clients = new RouterSocket(connStr.Value))
    using (var workers = new DealerSocket())
    {
        workers.Bind("inproc://workers");
        for (var i = 0; i < workerCount; ++i)
        {
            Task.Factory.StartNew(Worker
                , cancellationTokenSource.Token
                , TaskCreationOptions.LongRunning
                , TaskScheduler.Default);
        }
        var prx = new Proxy(clients, workers);
        prx.Start();
    }
    private void Worker()
    {
        using (var socket = new ResponseSocket())
        {
            socket.Connect("inproc://workers");
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                 //...
            }
            // Cancel the task and exit
            cancellationTokenSource.Token.ThrowIfCancellationRequested();
        }
    }
