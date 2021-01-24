    DispatcherTimer _timer;
    bool cancelled;
    async void Click()
    {
        if (_timer != null)
        {
            _timer.Stop();
            _timer.Dispose();
        }
        ErrorPanel.Visibility = Visibility.Visible;
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(10);
        _timer.Tick += _timer_Tick;
        _timer.Start();
        var products = await Task.Run(() => Communication.GetProductList(tempPznList));
        _timer.Stop();
        if (!cancelled)
        {
            mainPznItem.SubPzns = products;
            ErrorPanel.Visibility = Visibility.Hidden;
        }
    }
    private void _timer_Tick(object sender, EventArgs e)
    {
        MessageBox.Show("error...");
        _timer.Tick -= _timer_Tick;
        _timer.Stop();
        cancelled = true;
        ErrorPanel.Visibility = Visibility.Hidden;
    }
