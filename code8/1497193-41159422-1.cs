    public ExtendedSplash(SplashScreen splashscreen, bool loadState)
    {
        InitializeComponent()
      try
        {
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
        }
        catch (Exception ex)
        {
            Log.print(ex.StackTrace);
        }
    
        splash = splashscreen;
    
        if (splash != null)
        {
            // Register an event handler to be executed when the splash screen has been dismissed.
            splash.Dismissed += new TypedEventHandler<SplashScreen, Object>(DismissedEventHandler);
            // Create a Frame to act as the navigation context
            rootFrame = new Frame();
            DismissExtendedSplash();
        }
    }
