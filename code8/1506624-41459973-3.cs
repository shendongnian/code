    void worker(int workerId)
    {
        Console.WriteLine("Worker {0} is starting.", workerId);
        do {
            string op;
            while(iQ.TryDequeue(out op))
            {
                Console.WriteLine("Worker {0} is processing item {1}", workerId, op);
            }
            SpinWait.SpinUntil(() => Volatile.Read(ref doneEnqueueing) || (iQ.Count > 0));
        }
        while (!Volatile.Read(ref doneEnqueueing) || (iQ.Count > 0))
        Console.WriteLine("Worker {0} is stopping.", workerId);
    }  
