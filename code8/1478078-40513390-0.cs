    private async void Initialize(IActivatedEventArgs args)
    {
        // My code copied from original OnLaunched method with some minor changes
    }
    protected override void OnActivated(IActivatedEventArgs args)
    {
        Initialize(args);
    }
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        Initialize(e);
    }
