    public void Run(IBackgroundTaskInstance taskInstance)
    {
        mDeferral = taskInstance.GetDeferral();
        ...
        mDeferral.Complete();       
    }
