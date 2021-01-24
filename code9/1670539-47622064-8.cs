    var pendingThreads = ThreadsNumber;
    // ...
    for (var i = 0; i < ThreadsNumber; i++)
    {
        // ...
        threads[i] = new Thread
        (
            () =>
            {
                output[index] = Sum(start, end);
                if (Interlocked.Decrement(ref pendingThreads) == 0)
                {
                    sw.Stop();
                    finished?.Invoke
                    (
                        this,
                        new CalcFinishedEventArgs()
                        {
                            Result = output.Sum(),
                            Time = sw.ElapsedMilliseconds
                        }
                    );
                }
            }
        );
        // ...
    }
