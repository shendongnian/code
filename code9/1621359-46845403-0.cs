    while(!cancellationToken.IsCancellationRequested)
    {
        // Do stuff
        
        // Also check before doing something that may block or take a while
        if(!cancellationToken.IsCancellationRequested)
        {
            Stream.Read(buffer, 0, n);
        }
    }
