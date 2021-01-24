    while (!cancellationToken.IsCancellationRequested)
    {
        var updates = await Get100Updates();
        foreach (var upt in updates)
        {
            Q.Enqueue(upt); // This is referring to the Queueing System, don't take it literally
        }
    }
