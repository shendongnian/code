    for (int i = 0; i < 1000; i++)
    {
        DateTime beginTime = DateTime.UtcNow;
    
        var sw = Stopwatch.StartNew();
    
        while (sw.ElapsedTicks < 100)
        {
            Console.WriteLine("*");
        }
        long elapsedTicks = DateTime.UtcNow.Ticks - beginTime.Ticks;
        Console.WriteLine("   {0:N0} nanoseconds", elapsedTicks * 100);
    }
