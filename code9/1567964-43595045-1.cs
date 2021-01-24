    async Task RunPeriodicQuery()
    {
        TimeSpan interval = TimeSpan.FromMinutes(5);
        while (true)
        {
            await Task.Delay(interval);
            string result = await Task.Run((Func<string>)SQLDataTotalCalls);
            // do something with "result" here...you'll be in the UI thread, so make it quick
        }
    }
