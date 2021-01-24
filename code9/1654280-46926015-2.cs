    var aTimer = new System.Timers.Timer(rts.TotalMilliseconds); 
     //here you can use the same time span above.
    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    aTimer.Enabled = true; 
    private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        MessageBox.Show("The batch is completed!");
    }
