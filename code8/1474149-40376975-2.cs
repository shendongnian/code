    // a field to store the guiDispatcher.
    Dispatcher guiDispatcher;
    // wait event.
    ManualResetEvent dispatcherInitialized = new ManualResetEvent(false);
    Thread viewerThread = new Thread(delegate ()
    {
        Window window = GetDialog(configuration);
        window.Show();
        // get a/the dispatcher of this thread.
        guiDispatcher = Dispatcher.CurrentDispatcher;
        // dispatcher initialized. Set wait event.
        dispatcherInitialized.Set();
        // run dispatcher.
        System.Windows.Threading.Dispatcher.Run();
    });
    viewerThread.SetApartmentState(ApartmentState.STA);
    viewerThread.Start();
    dispatcherInitialized.WaitOne();
    // ......
    // when you want to terminate the thread, just shutdown the dispatcher.
    guiDispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
    // you might want to wait until the thread is terminated.
    viewerThread.Join();
