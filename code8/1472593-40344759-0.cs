    // Problems (1), (3), (6)
    result = Task.Run(async () => await task()).ConfigureAwait(false).GetAwaiter().GetResult();
    // Problems (1), (3)
    result = Task.Run(task).ConfigureAwait(false).GetAwaiter().GetResult();
    // Problems (1), (7)
    result = task().ConfigureAwait(false).GetAwaiter().GetResult();
    // Problems (2), (3)
    result = Task.Run(task).Result;
    // Problems (3)
    result = Task.Run(task).GetAwaiter().GetResult();
    // Problems (2), (4)
    var t = task();
    t.RunSynchronously();
    result = t.Result;
    // Problems (2), (5)
    var t1 = task();
    Task.WaitAll(t1);
    result = t1.Result;
