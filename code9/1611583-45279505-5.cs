    [Service]
    public class PeriodicService : Service
    { 
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            // From shared code or in your PCL
            
    
            return StartCommandResult.NotSticky;
        }
    }
