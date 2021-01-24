    protected override async void OnLaunched(LaunchActivatedEventArgs e)
    { 
        if (System.Diagnostics.Debugger.IsAttached)
        {
            this.DebugSettings.EnableFrameRateCounter = true;
        } 
        Frame rootFrame = Window.Current.Content as Frame;  
        if (rootFrame == null)
        {
            // Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = new Frame();
            rootFrame.NavigationFailed += OnNavigationFailed;
            if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                //TODO: Load state from previously suspended application
            }
            // Place the frame in the current Window
            Window.Current.Content = rootFrame;
        }
       ///Get all the screens.
        String projectorSelectorQuery = ProjectionManager.GetDeviceSelector();
        var outputDevices = await DeviceInformation.FindAllAsync(projectorSelectorQuery);
        //if(outputDevices.Count==1)
        //{
        //}
        int thisViewId;
        int newViewId = 0;
        ///Choose one screen for display .
        DeviceInformation showDevice = outputDevices[1];
        thisViewId = ApplicationView.GetForCurrentView().Id;
        if (e.PrelaunchActivated == false)
        {
            if (rootFrame.Content == null)
            { 
            }          
            Window.Current.Activate();
        }
        ///Create a new view
        await CoreApplication.CreateNewView().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            Frame frame = new Frame();
            frame.Navigate(typeof(MainPage), null);
            Window.Current.Content = frame;          
            Window.Current.Activate();
            newViewId = ApplicationView.GetForCurrentView().Id;
        });
        await ProjectionManager.StartProjectingAsync(newViewId, thisViewId, showDevice); 
        
    }
