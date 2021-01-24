    var lastTime = CrossSettings.Current.GetValueOrDefault("lastTime", DateTime.MinValue);
    if (lastTime + TimeSpan.FromDays(1) > DateTime.UtcNow)
    {
        // grab new value from the array
        // save the time
        // save the index
        // display it
    }
