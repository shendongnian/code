    System.Timers.Timer timer1 = new System.Timers.Timer();
                timer1.Interval = 1000;  //milliseconds after which you want to exit the application
                timer1.Start();
                timer1.Elapsed += TimerTick;
    
     private void TimerTick(object sender, ElapsedEventArgs e)
      {
        if (Win32.GetIdleTime() > 1000)
          {
             Environment.exit();
          }
      }
