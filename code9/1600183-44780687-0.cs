    Views.InstallingWindow installing = new Views.InstallingWindow();
    installing.Show();
    System.Threading.Tasks.Task.Factory.StartNew(() =>
    {
        timeConsumingMethod();
    }).ContinueWith(task =>
    {
        installing.Close();
    }, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskContinuationOptions.None, 
