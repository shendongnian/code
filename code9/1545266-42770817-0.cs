    Window1 tempWindow = null;
    Thread newWindowThread = new Thread(new ThreadStart(() =>
    {
        SynchronizationContext.SetSynchronizationContext(
        new DispatcherSynchronizationContext(
            Dispatcher.CurrentDispatcher));
        tempWindow = new Window1();
        tempWindow.Content = new ProgressBar() { IsIndeterminate = true };
        tempWindow.Closed += (ss, ee) =>
        Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
        tempWindow.Show();
        System.Windows.Threading.Dispatcher.Run();
    }));
    newWindowThread.SetApartmentState(ApartmentState.STA);
    newWindowThread.IsBackground = true;
    newWindowThread.Start();
    ReportWindow rw = new ReportWindow();
    rw.PrintReport();
    rw.Close();
    if (tempWindow != null)
        tempWindow.Dispatcher.Invoke(new Action(() => tempWindow.Close())); 
