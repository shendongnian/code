    private BackgroundWorker _bgWorker = new BackgroundWorker();
    public void Main(string[] args)
    {
        _bgWorker.DoWork += _bgWorker_DoWork;
        _bgWorker.RunWorkerAsync();
    }
    private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        while (!_bgWorker.CancellationPending)
        {
            // Do things for your install here.
        }
        // Display your dialog asking if they'd like to continue.
        if (!userWantsToContinue)
        {
            // Do rollback logic here.
            return;
        }
        else
        {
            // Do the rest of your install.
        }
    }
