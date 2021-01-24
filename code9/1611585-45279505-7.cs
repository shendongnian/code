    public class PeriodicService : Service
    { 
     private static Timer timer = new Timer();     
      public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            timer.scheduleAtFixedRate(new mainTask(), 0, 5000);
            return StartCommandResult.NotSticky;
        }
    
       private class mainTask extends TimerTask
        { 
            public void run() 
            {
             //your code
            }
        } 
    }
