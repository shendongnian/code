    int Ticks = 0, TickLimit = 1000;
    void StartTimer()
    {
       if (Checkbox.Checked.Equals(true))
       {
          var timeToWait = double.Parse(1000);
          var aTimer = new Timer();
          aTimer.Elapsed += OnTimedEventCheck;
          aTimer.Interval = timeToWait;
          aTimer.Enabled = true;
       }
    }
    void OnTimedEventCheck(object source, ElapsedEventArgs elapsed)
    {
       ++Ticks;
       if (AutoRScb.Checked.Equals(false))
       {
          aTimer.Stop();
          aTimer.Dispose();
          UpdateList("auto restarts dead");
       }
       else if (Ticks >= TickLimit)
       { MyTimedEvent(); Ticks = 0; }
    }
            
    void MyTimedEvent()
    { 
       //Your stuff here
    }
