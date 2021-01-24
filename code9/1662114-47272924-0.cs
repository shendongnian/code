    private volatile bool _done = false;
    void Main()
    {
        StartWorkerThreads();
    }
    void WorkerThread()
    {
        while (true)
        {
            if (_done) return; //Someone else solved the problem, so exit.
            ContinueSolvingTheProblem();
        }
        _done = true; //Tell everyone else to stop working.
    }
