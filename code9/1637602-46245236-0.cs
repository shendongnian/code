    RecurringJob.AddOrUpdate(() => PrintTime(), Cron.Minutely); 
    ...
    private static void PrintTime() {
        Console.WriteLine($"{DateTime.Now}");
    }
