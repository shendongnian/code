    // Create a thread
    Thread newWindowThread = new Thread(new ThreadStart(() =>
    {
        // Create our context, and install it:
        SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));
        Window1 tempWindow = new Window1();
        tempWindow.Content = new CircularProgressBar();
        // When the window closes, shut down the dispatcher
        tempWindow.Closed += (s, e) =>
        Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
        tempWindow.Show();
        // Start the Dispatcher Processing
        System.Windows.Threading.Dispatcher.Run();
    }));
    // Set the apartment state
    newWindowThread.SetApartmentState(ApartmentState.STA);
    // Make the thread a background thread
    newWindowThread.IsBackground = true;
    // Start the thread
    newWindowThread.Start();
