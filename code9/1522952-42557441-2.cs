    var thisInstance = new SingleInstance(user, method,   DateTimeOffset.UtcNow.AddMinutes(1));
    if (_single.TryAdd(thisInstance))
    {
        // tell the database to kick off some long running process
        DoLongRunningDatabaseProcess();
        // remove lock on running process
        _single.TryRemove(thisInstance);
    }
