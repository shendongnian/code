    [HubName("messageHub")]
    public class MessageHub : Hub  // This is your server-side SignalR
    {
        public async Task Countdown(IProgress<int> progress) // This is your IProgress
        {            
             // 60 second countdown for an example
             // NOT TESTED
             for (int i = 1; i <= 61; i += 1)
             {             
                  await Task.Delay(1000);
                  progress.Report(i);                    
             }
         }
    }
