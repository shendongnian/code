    TimeSpan period = TimeSpan.FromSeconds(60);
    
    ThreadPoolTimer PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
    {
        // 
        // TODO: Work
        // 
        // 
        // Update the UI thread by using the UI core dispatcher.
        // 
        Dispatcher.RunAsync(CoreDispatcherPriority.High,
            () =>
            {
                // 
                // UI components can be accessed within this scope.
                // 
            });
    }, period);
