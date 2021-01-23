    try
    {
        ...
    }
    catch (Exception ex) when (dict.ContainsKey(ex.GetType())
    {
        int mapTo = dict[ex.GetType()];
        // Use mapTo value here
    }
