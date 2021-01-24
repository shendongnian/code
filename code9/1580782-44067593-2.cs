    try
    {
        // ...
    }
    catch (AggregateException ex) when (ex.InnerException is UserNotFoundException)
    {
        // ...
    }
    catch (AggregateException ex) when (ex.InnerException is SomeOtherException)
    {
        // ...
    }
