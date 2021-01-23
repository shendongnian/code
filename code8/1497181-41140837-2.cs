    try
    {
        ...
    }
    catch (Exception ex) when (dict.Contains(ex.GetType())
    {
        int mapTo = dict[ex.GetType()];
        // Use mapTo value here
    }
