    System.Timers.Timer timer = new System.Timers.Timer(1000); //it will run every one second
    
    public void OnCaptured(CaptureResult captureResult)
    {
         timer.Elapsed += TimeCountDown_Tick;
         timer.Start();
    }
    
    private void TimeCountDown_Tick(object sender, System.Timers.ElapsedEventArgs e)
     {
        int count = int.Parse(lblCount.Text) -1;
        InvokeCD(count.ToString());
         if (count < 0) {
           TimeCountDown.Enabled = false;
           InvokeCD("5");
         }
    }
