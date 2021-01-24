        private async void RunTimerAsync()
        {
               await Timer();
        }
        
        private async Task Timer()
        {
             while (IsTimerStarted)
             {
                   //Your piece of code for each timespan
                   //ElapsedTime += TimeSpan.FromSeconds(1.5);
                   await Task.Delay(TimeSpan.FromSeconds(1.5));
             }
       }
