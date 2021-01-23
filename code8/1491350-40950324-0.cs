    using Microsoft.Services.Store.Engagement;
      public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            RegisterNotificationChannelAsync();
        }
        private async void RegisterNotificationChannelAsync()
        {
            StoreServicesEngagementManager manager = StoreServicesEngagementManager.GetDefault();
            await manager.RegisterNotificationChannelAsync();
        }
    protected override void OnActivated(IActivatedEventArgs args)
    {
    base.OnActivated(args);
    if (args is ToastNotificationActivatedEventArgs)
    {
        var toastActivationArgs = args as ToastNotificationActivatedEventArgs;
        StoreServicesEngagementManager engagementManager = StoreServicesEngagementManager.GetDefault();
        string originalArgs = engagementManager.ParseArgumentsAndTrackAppLaunch(
            toastActivationArgs.Argument);
    } 
