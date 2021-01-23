    while (sw.ElapsedMilliseconds < time)
    {
        if (token.IsCancellationRequested)
        {
            Console.WriteLine("Cancelled");
            return;
        }
        Thread.SpinWait(1000);
    }
