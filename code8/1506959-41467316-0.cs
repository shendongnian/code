    DateTime timerStart = DateTime.Now;
    System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
    dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
    dispatcherTimer.Start();
    
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
         var currentValue = DateTime.Now - timerStart; 
         TokenGrid["ExpiryTime", row].Value = currentValue.Seconds.ToString();
    }
