    protected override void OnActivated(IActivatedEventArgs args)
        {
            Initialize(args);
            if (args.Kind == ActivationKind.Protocol)
            {
                ProtocolActivatedEventArgs eventArgs = args as ProtocolActivatedEventArgs;
                Frame rootFrame = Window.Current.Content as Frame;
                if (rootFrame == null)
                {
                    // Create a Frame to act as the navigation context and navigate to the first page
                    rootFrame = new Frame();
                    rootFrame.NavigationFailed += OnNavigationFailed;
                    // Place the frame in the current Window
                    Window.Current.Content = rootFrame;
                }
                // Always navigate for a protocol launch
                rootFrame.Navigate(typeof(MainPage), eventArgs.Uri.AbsoluteUri);
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }
