    public async void Run(IBackgroundTaskInstance taskInstance)
    {
        taskInstance.Canceled += OnCanceled;
    }
    private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
    {
        // Cleanup
    }
    
            
