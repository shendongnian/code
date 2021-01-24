    if (idx == 0) {
        check.ContinueWith(t =>
        {
             // observe, maybe do something like logging it
             var e = t.Exception;
        }, TaskContinuationOptions.OnlyOnFaulted);
        throw new TimeoutException("FREEZE DETECTED");
    }
