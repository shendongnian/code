    if (idx == 0) {
        check.ContinueWith(t =>
        {
             // observe, maybe do something like logging it
             var e = check.Exception;
        }, TaskContinuationOptions.OnlyOnFaulted);
        throw new TimeoutException("FREEZE DETECTED");
    }
