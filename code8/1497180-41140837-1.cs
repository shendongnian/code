    try
    {
        ...
    }
    catch (Exception ex)
    {
        int mapTo;
        if (dict.TryGetValue(ex.GetType(), out mapTo))
        {
            // Use mapTo value here
        }
    }
