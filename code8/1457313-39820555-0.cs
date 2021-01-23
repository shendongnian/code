    Stopwatch watch = new Stopwatch();
    int[] testArray = new int[] { 1, 2, 3, 4, 5 };
    int? test = null;
    watch.Start();
    for (int i = 0; i < 10000; i++)
    {
        try
        {
            testArray[(int)test] = 0;
        }
        catch { }
    }
    watch.Stop();
    Console.WriteLine("try-catch result:");
    Console.WriteLine(watch.Elapsed);
    Console.WriteLine();
    watch.Restart();
    for (int i = 0; i < 10000; i++)
    {
        if (test != null)
            testArray[(int)test] = 0;
    }
    watch.Stop();
            
    Console.WriteLine("if-statement result:");
    Console.WriteLine(watch.Elapsed);
