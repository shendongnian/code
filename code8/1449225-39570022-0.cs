    //Function triggered by a timespan schedule every 5 sec.
    public static void TimerJob([TimerTrigger("*/5 * * * * *")] TimerInfo timerInfo)
    {
        Console.WriteLine("Timer job fired!");
    }
