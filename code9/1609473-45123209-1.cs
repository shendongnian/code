    // runs in a background thread
    public void backgroundFoo()
    {
        // do heavy stuff here
        var result = Work();
        Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new Action(() => 
        {
            // update UI here after the work as been done ...
            Console.WriteLine(... result.Anything ...);
        }));
    }
