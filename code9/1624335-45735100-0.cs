    private void Start_Thread()
    {
        Window win = new Window();
        win.Content = new YourUserControl();
        win.Show();
        Task.Factory.StartNew(() =>
        {
            Sample_Thread();
        }).ContinueWith(task =>
        {
            //this code runs back on the UI thread once the task has finished
            win.Close();
        }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
    }
