    DispatcherTimer _timer;
    
    private int i = 0;
    
    public bool SomethingIsOn { get; private set; } = true;
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (_timer == null && SomethingIsOn)
        {
            _timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(300)
            };
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }
      else if(_timer != null)
        {
            _timer.Stop();
            ((Button)sender).IsEnabled = false;
        }
    }
    
    private void _timer_Tick(object sender, object e)
    {
        if (SomethingIsOn)
        {
            i++;
            DisplayTextBlock.Text = i.ToString();
        }
    }
