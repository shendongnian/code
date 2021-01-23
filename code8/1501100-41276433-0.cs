    private static async Task RunEveryMillisecond(CancellationToken token)
    {
        Stopwatch s = Stopwatch.StartNew();
        TimeSpan prevValue = TimeSpan.Zero;
        int i = 0;
        while (true)
        {
            Console.WriteLine(s.ElapsedMilliseconds);
            await MultimediaTimer.Delay(1, token);
            if (Console.KeyAvailable)
            {
                return;
            }
            i++;
        }
    }
