    static async void Test() {
        var originalTask = CrashAsync("aaa");
        var onSuccess = originalTask.ContinueWith(async (t) =>
        {
            await CrashAsync("bbb");
        }, TaskContinuationOptions.OnlyOnRanToCompletion);
        var onFault = originalTask.ContinueWith(t => {                    
            Log("Observed original exception: " + t.Exception.InnerExceptions[0].Message);
        }, TaskContinuationOptions.OnlyOnFaulted);
    }
