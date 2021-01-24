    var client = new HttpClient();
    var tasks = new HashSet<Task>();
    foreach(var url in urls)
    {
        if(tasks.Count == m)
        {
            tasks.Remove(await Task.WhenAny(tasks));            
        }
        
        tasks.Add(((Func<Task>)(async () =>
        {
            var response = await client.GetAsync(url); // possibly ConfigureAwait(false) here
            // do something with response            
        }))());
    }
    await Task.WhenAll(tasks);
