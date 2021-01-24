    using System;
    
    public static async Task Run(TimerInfo myTimer, IAsyncCollector<Notification> notification, TraceWriter log)
    {
        log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
        await notification.AddAsync(new Notification(){
            // your code here
    
        });
    }
