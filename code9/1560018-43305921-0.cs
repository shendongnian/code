    Task activeOperation = null;
    while (true)
    {
        if (activeOperation == null)
        {
            // No async operation in progress. Start a new one.
            activeOperation = RunAsync();
        }
        else if (activeOperation.IsCompleted)
        {
            // Do something with the result.
            // Clear active operation so that we get a new one
            // in the next iteration.
            activeOperation = null;
        }
        // Do some other stuff
    }
