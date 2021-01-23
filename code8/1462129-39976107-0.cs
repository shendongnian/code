            /// <summary>
            /// Initializes the singleton application object.  This is the first line of authored code
            /// executed, and as such is the logical equivalent of main() or WinMain().
            /// </summary>
            public App()
            {
                Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
                this.InitializeComponent();
                this.Suspending += OnSuspending;
            }
        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            #if DEBUG
                        Debug.WriteLine($"Installed location: {Windows.ApplicationModel.Package.Current.InstalledLocation.Path}");
                        if (System.Diagnostics.Debugger.IsAttached)
                        {
                            this.DebugSettings.EnableFrameRateCounter = false;
                        }
        #endif
            RootFrame = Window.Current.Content as Frame;
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (RootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                RootFrame = new Frame();
                RootFrame.NavigationFailed += OnNavigationFailed;
                Debug.WriteLine(e.PreviousExecutionState);
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated || e.PreviousExecutionState == ApplicationExecutionState.ClosedByUser)
                {
                    await xxxxx.Common.SuspensionManager.RestoreAsync();
                }
                if (true)
                {
                    try
                    {
                            await xxxx(await Utils.DeserializeXML<xxx>(
                            await ApplicationData.Current.LocalFolder.GetFileAsync("xxx.xml")));
                    }
                    catch
                    {
                        Debug.WriteLine("No in xxx");
                    }
                }
                // Place the frame in the current Window
                Window.Current.Content = RootFrame;
                await AssetManager.InitAssets();
                // Place the frame in the current Window
                await AssetManager.FetchAssets();
            }
            if (RootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (App.xxxx == null || App.xxxx.SessionId == null)
                    RootFrame.Navigate(typeof(xxxPage), e.Arguments);
                else
                    RootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }
        
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("xxxxxx " + e.SourcePageType.FullName);
        }
        
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            // it would be best to have a SUSPEND state in the statechart for every possible
            // state, but it's ok for now
            Utils.ReleaseDisplay();
            var deferral = e.SuspendingOperation.GetDeferral();
            try {
                if (App.LoggedUser != null)
                {
                    await Utils.SerializeXML(await ApplicationData.Current.LocalFolder.CreateFileAsync(
                    "xxx.xml", CreationCollisionOption.ReplaceExisting), xxxxx);
                    await Utils.SerializeXML(await App.xxxFolder.CreateFileAsync(
                    "xxx.xml", CreationCollisionOption.ReplaceExisting), App.State);
                }
            }
            catch (Exception e2)
            {
                Debug.WriteLine(e2);
            }
            await xxxxx.Common.SuspensionManager.SaveAsync();
            deferral.Complete();
        }
    }
