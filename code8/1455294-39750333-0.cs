    try
    {
       await Task.WhenAll(tasks);
    }
    catch (AggregateException)
    {
       // handle exceptions
    }
    
    foreach(var item in tasks.Where(x=>x.Status == TaskStatus.RanToCompletion).Select(x=>x.Result))
    {
        item.Dispose();
    }
