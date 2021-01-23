    TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    Task.Factory.StartNew( () => Thread.Sleep( 10000 ) )
        .ContinueWith(
            t => UpdateGuItemsAsync(),
            CancellationToken.None,
            TaskContinuationOptions.None,
            uiScheduler );
    public void UpdateGuItemsAsync()
    {
        // System.Threading.Thread.Sleep(10000);
        for (int i = 0; i < 100; i++)
        {
            Gu45Document gu45Document = new Gu45Document();
            gu45Document.Form = "EU-45";
            Gu45Documents.Add(gu45Document);
        }
    }
