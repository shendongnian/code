    //Function triggered by a timespan schedule every 5 sec.
    public static async void ProcessAugustEndowments([TimerTrigger("*/5 * * * * *", RunOnStartup = true)] TimerInfo timerInfo)
    {
        Console.WriteLine("Endowments process tried");
        await endowmentNotification();
    }
    private static async Task endowmentNotification()
    {   
        //sleep for 2 sec to simulate processing business logic
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
