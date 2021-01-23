    private void ApacheTest()
    {
        if(!File.Exists(HTTPD_PATH))
        {
            amountdl.Text = "Apache Not Found! Installation Corrupt!";
            return;
        }
        amountdl.Text = "Apache Is Starting";
        Task.Factory.StartNew(() =>
            {
                while(ApacheRunning() == false)
                {
                    Thread.Sleep(200);
                }
                amountdl.Text = "Apache Started";
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.FromCurrentSynchronizationContext()); // nicked from [the MSDN forums][1]
    }
