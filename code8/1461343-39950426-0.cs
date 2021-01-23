    try
    {
        await t1;
    }
    catch (AggregateException ex)
    {
        var innerEx = ex.InnerExceptions[0];
        if (innerEx is NotSupportedException)
        {
            ...
        }
        else if (innerEx is NotImplementedException)
        {
            ...
        }
        else
        {
            ...
        }
    }
