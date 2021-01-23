    try
    {
        try
        {
           await Task.WhenAll(tasks);
        }
        catch (AggregateException)
        {
           // handle exceptions
        }
        //do other stuff with the returned task objects.
    }
    finally
    {    
        foreach(var item in tasks.Where(x=>x.Status == TaskStatus.RanToCompletion).Select(x=>x.Result))
        {
            //We use a try block so if Dispose throws it does not break the loop.
            try
            {
                item.Dispose();
            }
            catch(Exception ex)
            {
                //Log any exception on dispose.
            }
        }
    }
