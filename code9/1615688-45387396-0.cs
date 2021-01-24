    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        ...
        if (rootFrame == null)
        {
            ...
            // Register a handler for BackRequested events
            SystemNavigationManager.GetForCurrentView().BackRequested += this.OnBackRequested;
        }
        ...
    }
