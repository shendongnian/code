    try
    {
        var t = Task.Run(TestAsync);
        t.Wait();
    }
    catch (AggregateException ex) when (ex.InnerException is CustomException)
    {
        throw;
    }
    catch (Exception)
    {
        //handle exception here
    }
