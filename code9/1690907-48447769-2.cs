    //the public method returns an IAsyncOperation<T> that wraps the private method that returns a .NET Task<T>:
    public static async IAsyncOperation<BackgroundTaskRegistration> RegisterBackgroundTask(
    string taskEntryPoint,
    string taskName,
    IBackgroundTrigger trigger,
    IBackgroundCondition condition)
    {
        return RegisterBackgroundTask(taskEntryPoint, taskName, trigger, condition).AsAsyncOperation();
    }
    //change your current method to be private:
    private static async Task<BackgroundTaskRegistration> RegisterBackgroundTask(
        string taskEntryPoint,
        string taskName,
        IBackgroundTrigger trigger,
        IBackgroundCondition condition)
    {
        //...
    }
