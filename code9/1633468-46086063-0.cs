    var processingTasks = targets.Select(async t =>
    {
        try
        {
            if(!await t.SendAsync(item))
                await t.Completion;
        }
        catch
        {
            Trace.TraceInformation("handled in select"); // never goes here
        }
    });
