    public static async Task Run(TimerInfo myTimer, TraceWriter log)
    {
        log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
        await CallHttpClient(log);
    }
    
    public static async Task CallHttpClient(TraceWriter log)
    {
        using (var httpClient = new HttpClient())
        {
            var str = await httpClient.GetStringAsync("https://www.google.com");
            log.Info(str);
        }
    }
