    using (var cts = new CancellationTokenSource())
    {
        var tasks = new List<Task<HttpStatusCode>>();
    
        foreach (var url in patterns)
        {
            tasks.Add(GetStatusCodeAsync(url, cts.Token));
        }
    
        while (tasks.Any() && !cts.IsCancellationRequested)
        {
            Task<HttpStatusCode> task = await Task.WhenAny(tasks);
    
            if (await task == HttpStatusCode.Unauthorized)
            {
                cts.Cancel();
                // Handle the "found" situation
                // ...
            }
            else
            {
                tasks.Remove(task);
            }
        }
    }
