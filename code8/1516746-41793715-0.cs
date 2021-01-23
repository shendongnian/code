    private int _progress;
    private delegate void Delegate();
    private void btnStartTask_Click(object sender, EventArgs e)
    {
        // Initialize progress bar to 0 and task a new task
        _progress = 0;
        progressBar1.Value = 0;
        Task.Factory.StartNew(DoTask);
    }
    private void DoTask()
    {
        // Simulate a long 5 second task
        // Obviously you'll replace this with your own task
        for (int i = 0; i < 5; i++)
        {
            System.Threading.Thread.Sleep(1000);
            _progress = (i + 1)*20;
            if (progressBar1.InvokeRequired)
            {
                var myDelegate = new Delegate(UpdateProgressBar);
                progressBar1.Invoke(myDelegate);
            }
            else
            {
                UpdateProgressBar();
            }
        }
    }
    private void UpdateProgressBar()
    {
        progressBar1.Value = _progress;
    }
