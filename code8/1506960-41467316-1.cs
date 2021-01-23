    const int MAX_DURATION = 120;
    DateTime timerStart = DateTime.Now;
    System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    EventHandler handler = new EventHandler(dispatcherTimer_Tick);
    dispatcherTimer.Tick += handler;
    dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
    dispatcherTimer.Start();
     
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
         // Display seconds 
         var currentValue = DateTime.Now - timerStart; 
         TokenGrid["ExpiryTime", row].Value = currentValue.Seconds.ToString();
         // When the MAX_DURATION (2 minutes) is reached, stop the timer
         if (currentValue >= MAX_DURATION) {
             dispatcherTimer.Tick -= handler;
             dispatcherTimer.Stop();
             TokenGrid.Rows.RemoveAt(row);
         }
    }
