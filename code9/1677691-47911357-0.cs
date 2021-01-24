    using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisHost))
    {
        IDatabase db = redis.GetDatabase();
        foreach (var filename in filenames)
        {
            tasks.Add(db.SortedSetAddAsync("files", filename, 0));
        }
        Console.WriteLine($"Task count: {tasks.Count}");
         
        await Task.WhenAll(tasks.ToArray());
    }
