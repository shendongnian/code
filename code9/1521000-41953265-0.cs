    //All code below is executed on a background thread
    //Line below causes WPF framework to add something to Dispatcher.CurrentDispatcher queue.
    view.Filter = new Predicate<Object>(actionTarget.FilterCallback); 
                 
    if (Thread.CurrentThread.IsBackground &&  Dispatcher.CurrentDispatcher != Application.Current.Dispatcher)
    {
        Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
        Dispatcher.Run();
    }
