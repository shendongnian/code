    private void UpdateGuItemsAsync()
    {
        //This line must be called on the UI thread
        var timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(10);
        timer.Tick += OnUpdateGuiItemsTimerTick;
        timer.Start();
    }
    private void OnUpdateGuiItemsTimerTick(object sender, EventArgs e)
    {
        //Stop the timer.
        var timer = sender as DispatcherTimer;
        timer.Stop();
        //Run the code you where waiting for.
        for (int i = 0; i < 100; i++)
        {
            Gu45Document gu45Document = new Gu45Document();
            gu45Document.Form = "EU-45";
            Gu45Documents.Add(gu45Document);
        }
    }
