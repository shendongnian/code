    while (!queue.IsCompleted)
    {
        object obj;
        
        try
        {
            obj = queue.Take();
        }
        catch (InvalidOperationException)
        {
            continue;
        }
        
        // Do something with obj.
    }
