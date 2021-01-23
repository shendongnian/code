    private BackgroundWorker worker = new BackgroundWorker();
    private TaskCompletionSource<object> _tcs;
    
    public Form1()
    {
        InitializeComponent();
    
        worker.DoWork += worker_DoWork;
        // Need to reinitialize when you actually start the worker...you
        // didn't show that code, so I'm putting it here
        _tcs = new TaskCompletionSource<object>();
    }
    
    public async Task Cancel()
    {
        worker.CancelAsync();
        try
        {
            await _tcs.Task;
            // you'll be here if the task completed normally
        }
        catch (TaskCancelledException)
        {
            // you'll be here if the task was cancelled
        }
    }
    
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        while(!e.CancellationPending)
        {
            // do something
        }
    
        if (e.CancellationPending)
        {
            _tcs.SetCanceled();
        }
        else
        {
            // if you actually want to return a value, you can set whatever
            // value you want here. You can also use the correct type T for
            // the TaskCompletionSource<T> declaration.
            _tcs.SetResult(null);
        }
    }
