    var cancellationSource = new CancellationTokenSource();
    // Start the tasks
    var tasks = new List<Task<bool>>
    {
        WebService(cancellationSource.Token),
        WebService(cancellationSource.Token),
        WebService(cancellationSource.Token),
        WebService(cancellationSource.Token)
    };
    
    // Wait until first task returns true
    bool success = false;
    while (!success && tasks.Any())
    {
        var completedTask = await Task.WhenAny(tasks);
        try
        {
            // It either completed or failed, try to get the result
            success = await completedTask;
        }
        catch (Exception ex)
        {
            // ignore or log exception
        }
        tasks.Remove(completedTask);
    }
    // Cancel remaining tasks
    cancellationSource.Cancel();
    // Ensure all tasks have completed to avoid unobserved exceptions
    if (tasks.Any())
    {
        try
        {	        
            await Task.WhenAll(tasks);
        }
        catch (Exception ex)
        {
            // ignore or log exception
        }
    }
    if (success)
    {
        PostProcessing();
    }
