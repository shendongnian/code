    using Xamarin.Forms;
    using System;
    using System.Linq;
    using System.Diagnostics;
    
    namespace YourNamespace
    {
    	public partial class App : Application
    	{
    		private static Stopwatch stopWatch = new Stopwatch();
    		private const int defaultTimespan = 1;
    
    		protected override void OnStart()
    		{
    			// On start runs when your application launches from a closed state, 
    
    			if (!stopWatch.IsRunning)
    			{
    				stopWatch.Start();
    			}
    
    			Device.StartTimer(new TimeSpan(0, 0, 1), () =>
    			{
    				// Logic for logging out if the device is inactive for a period of time.
    
    				if (stopWatch.IsRunning && stopWatch.Elapsed.Minutes >= defaultTimespan)
    				{
    					//prepare to perform your data pull here as we have hit the 1 minute mark	
    					
    						// Perform your long running operations here.
    						
    						Device.InvokeOnMainThread(()=>{
    							// If you need to do anything with your UI, you need to wrap it in this.
    						});
    					
    					stopwatch.Restart();
    				}
    
    				// Always return true as to keep our device timer running.
    				return true;
    			});
    		}
    	
    		protected override void OnSleep()
    		{
    			// Ensure our stopwatch is reset so the elapsed time is 0.
    			stopWatch.Reset();
    		}
    
    		protected override void OnResume()
    		{
    			// App enters the foreground so start our stopwatch again.
    			stopWatch.Start();
    		}
    	}
    }
