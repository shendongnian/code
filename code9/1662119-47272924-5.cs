    //When signalled, indicates threads can proceed.
    //When reset, threads should pause as soon as possible.
    //Constructor argument = true so it is set by default
    private ManualResetEvent _go = new ManualResetEvent(true);
    void Main()
    {
        StartWorkerThreads();
    }
    void WorkerThread()
    {
        while (true)
        {
            _go.WaitOne();  //Pause if the go event has been reset
            ContinueSolvingTheProblem();
        }
        _go.Reset();  //Reset the go event in order to pause the other threads
    }
