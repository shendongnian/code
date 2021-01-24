    System.Windows.Threading.DispatcherTimer timer = new DispatcherTimer(); 
    private DateTime timeout;
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        timeout = DateTime.Now.AddSeconds(2);
        timer.Tick += Timer_Tick;
        timer.Interval = TimeSpan.FromMilliseconds(250);
        timer.Start();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        if (State().Equals(Online))
        {
            onLine = true;
            operationCompleted();
            timer.Stop();
        }
        if (DateTime.Now > timeout)
        {
            timer.Stop();
            MessageBox.Show("Error");
        }
    }
    // rest of code omitted
