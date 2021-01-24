    Delegate.Job1(request)
        .ContinueWith(Delegate.Job2, TaskContinuationOptions.OnlyOnRanToCompletion)
        .ContinueWith(Fault, TaskContinuationOptions.OnlyOnFaulted)
        .ContinueWith(Result, TaskContinuationOptions.OnlyOnRanToCompletion)
        .ContinueWith(Fault, TaskContinuationOptions.OnlyOnFaulted);
