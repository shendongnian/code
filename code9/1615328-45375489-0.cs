    public static void Main()
    {
        var delay = TimeSpan.FromSeconds(1);
        var cts = new CancellationTokenSource();
        var tasks = Enumerable.Range(0, 100).Select(i => Task.Run(() => SlowSqrt/*Async*/(i, delay, cts.Token), cts.Token)).ToArray();
        Thread.Sleep(3000);
        cts.Cancel();
    }
    public static double SlowSqrt(double arg, TimeSpan delay, CancellationToken token)
    {
        Console.WriteLine($"Calculating Sqrt({arg})...");
        var burnCpuTimeUntil = DateTime.Now + delay;
        while (DateTime.Now < burnCpuTimeUntil) token.ThrowIfCancellationRequested();
        var result = Math.Sqrt(arg);
        Console.WriteLine($"Sqrt({arg}) is {result}.");
        return result;
    }
    public static async Task<double> SlowSqrtAsync(double arg, TimeSpan delay, CancellationToken token)
    {
        Console.WriteLine($"Calculating Sqrt({arg})...");
        await Task.Delay(delay, token);
        var result = Math.Sqrt(arg);
        Console.WriteLine($"Sqrt({arg}) is {result}.");
        return result;
    }
