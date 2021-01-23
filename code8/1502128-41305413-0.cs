        protected override void OnStart(string[] args)
        {
            // Set the Interval to 1 seconds (1000 milliseconds).
            myTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer.
            myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            
            myTimer.Enabled = true;
        }
