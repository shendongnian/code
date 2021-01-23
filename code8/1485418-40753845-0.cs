    public static ConcurrentQueue<Result> AllResults { get; } = new ConcurrentQueue<Result>();
    ThreadPool.QueueUserWorkItem(state =>
    {
        Result r = function();
        AllResults.Enqueue(r);
    }
