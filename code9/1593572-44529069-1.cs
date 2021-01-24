    DateTime dateTime;
    if (DateTimeUtilities.TryParse(2017, 2, 30, out dateTime))
    {
        // success
    }
    else
    {
        // fail, dateTime = DateTime.MinValue
    }
