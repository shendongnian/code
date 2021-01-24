    try
    {
        // ...
    }
    catch (AggregateException ex)
    {
        if (ex.InnerException is UserNotFoundException)
        {
            // ...
        }
        else if (ex.InnerException is SomeOtherExeption)
        {
            // ...
        }
    }
