    static void Main(string[] args)
    {
        GlobalConfiguration.Configuration.UseMemoryStorage();
        BackgroundJob.Enqueue(() => Console.WriteLine("Easy!"));
        using (new BackgroundJobServer())
        {
            Console.WriteLine("Hangfire Server started. Press ENTER to exit...");
            Console.ReadLine();
        }
    }
