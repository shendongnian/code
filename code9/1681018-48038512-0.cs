    async void RunTaskAsync()
    {
        using(_cancelTknSource = new CancellationTokenSource())
    	{
    		_runningTask =Task.Run(/*...long running calculation...*/, _cancelTknSource.Token);
        	await _runningTask;
    	}
    }
    
    Task CancelAsync()
    {
       _cancelTknSource?.Cancel();
       return _runningTask;
    }
    Window.xaml.cs:
    
    async void Window_Closing(object sender, CancelEventArgs e)
    {
        e.Cancel = true;
        await DataContext.CancelAsync();
        Close();
    }
