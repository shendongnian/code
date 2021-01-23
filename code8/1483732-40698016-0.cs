     private void CreateTimer()
     {
         static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
         myTimer.Tick += new EventHandler(TimerEventProcessor);
          // Sets the timer interval to 1 minute.
          myTimer.Interval = 60000;
          myTimer.Start();
     }
    private static void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs) {
       myTimer.Stop();
       // Write code here to show the message box asking the user to save
       // Once the user has saved restart the timer
       myTimer.Start();
    }
