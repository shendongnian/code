    static async void Test() {
        try {
            var originalTask = CrashAsync("aaa");
            var onSuccess = originalTask.ContinueWith(async (t) =>
            {
                await CrashAsync("bbb");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            var onFault = originalTask.ContinueWith(t => {                    
                Log("Observed original exception: " + t.Exception.InnerExceptions[0].Message);
                }, TaskContinuationOptions.OnlyOnFaulted);
            await Task.WhenAny(onSuccess, onFault);
        }
        catch (TaskCanceledException exception) {
            Log($"observed exception");
            var ex = exception.Task.Exception;
            Log($"Exception: {exception.Message}");                
        }
    }
