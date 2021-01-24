    private volatile bool _done = false;
    private ManualResetEvent _go = new ManualResetEvent(true);
    void Main()
    {
        StartWorkerThreads();
    }
    void WorkerThread()
    {
        while (true)
        {
            if (_done) return; //Exit if problem has been solved
            _go.WaitOne();  //Pause if the go event has been reset
            if (_done) return; //Exit if problem was solved while we were waiting
            ContinueSolvingTheProblem();
        }
        _go.Reset();  //Reset the go event in order to pause the other threads
        VerifyAnswer();
        _done = true; //Set the done flag to indicate all threads should exit
    }
