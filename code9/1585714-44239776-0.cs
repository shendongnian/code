    Thread newWindowThread = new Thread(new ThreadStart(() =>
    {
        SynchronizationContext.SetSynchronizationContext(
            new DispatcherSynchronizationContext(
                Dispatcher.CurrentDispatcher));
        RxWindow tempWindow = new RxWindow();
        tempWindow.Closed += (ss, ee) => Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
        tempWindow.Show();
        Dispatcher.Run();
    }));
    newWindowThread.SetApartmentState(ApartmentState.STA);
    newWindowThread.IsBackground = true;
    newWindowThread.Start();
    newWindowThread.Name = "STA WPF";
