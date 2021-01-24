    private static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
    {
        if(unitsCount < 10)
        {    
            //launch Units
        }
     }
      
    public static void Main (string[] args) 
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed+=new System.Timers.ElapsedEventHandler(OnTimedEvent);
        
        aTimer.Interval=100;
        aTimer.Enabled=true;
    }
