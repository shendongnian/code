       public class StaticCache {        
          private static System.Timers.Timer syncTimer;
          
          StaticCache(){
            SetSyncTimer();
          }
          private void SetSyncTimer(){
        	// Create a timer with a five second interval.
        	syncTimer = new System.Timers.Timer(5000);
        
        	// Hook up the Elapsed event for the timer. 
        	syncTimer.Elapsed += SynchronizeCache;
        	syncTimer.AutoReset = true;
        	syncTimer.Enabled = true;
         }
         private static void SynchronizeCache(Object source, ElapsedEventArgs e)
         {
        	// do this stuff each 5 seconds
         }
        }
