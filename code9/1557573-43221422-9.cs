    public App()
    {
       TaskScheduler.UnobservedTaskException += OnUnobservedException;
    }
    
    private static void OnUnobservedException(object sender, UnobservedTaskExceptionEventArgs e)
    {
       // Put break point here.
       var ex = e.Exception;
    
       // This will keep your app alive, but only do it if it's safe to continue.
       e.SetObserved(); 
    }
