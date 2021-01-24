    private Timer _timer;
    int i = 0;
    private void _timer_Elapsed(object state)
    {
        if(SomethingIsOn)
        {
            i++;
            Dispatcher.Invoke(() => DisplayTextBlock.Text = i.ToString());
        }
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        _if(_timer == null && SomethingIsOn) // I made a property which is true by default
        {
            _timer = new Timer(_timer_Elapsed, null, 300, 300);
        }
        else if(_timer != null)
        {
            _timer.Change(0, -1); // Disable the timer.
            SomeButton.IsEnabled = false;
        }
    }
