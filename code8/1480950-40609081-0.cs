    var buffer = new BlockingCollection<string>();
    // Start reading thread
    var readTask = Task.Run(() =>
    {
        try
        {
            // Read data from source and put to buffer
            foreach (var data in source)
            {
                buffer.Add(data);
            }
        }
        finally
        {
            // Signal the end of the data
            buffer.CompleteAdding();
        }
    });
    // Start writing thread
    var writeTask = Task.Run(() =>
    {
        foreach (string data in buffer.GetConsumingEnumerable())
        {
            // Process data
        }
    });
    Task.WaitAll(readTask, writeTask);
