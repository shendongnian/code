    private readonly DispatcherTimer timer;
    public JustAViewModel()
    {
        timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
        timer.Tick += TimerTick;
        timer.Start();
    }
    private async void TimerTick(object sender, EventArgs e)
    {
        Value = await Task.Run(() => DataProvider.GetData());
    }
