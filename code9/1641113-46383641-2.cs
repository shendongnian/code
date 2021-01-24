    var client = new HttpClient();
    SemaphoreSlim semaphore = new SemaphoreSlim(m, m); //set the max here
    var tasks = new HashSet<Task>();
    foreach(var url in urls)
    {
        if(semaphore.CurrentCount == 0)
        {
            tasks.Remove(await Task.WhenAny(tasks));
            semaphore.Release();
        }
        await semaphore.WaitAsync(); //or just Wait
        tasks.Add(((Func<Task>)(async () =>
        {
            var response = await client.GetAsync(url);
            // do something with response            
        }))());
    }
    await Task.WhenAll(tasks);
