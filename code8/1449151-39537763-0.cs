    static void Main(string[] args)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (Console.ReadKey(true); ;)
        {
            TimeSpan ts = stopWatch.Elapsed;
            String elapsedTime = String.Format("{0:0}.{1:000}", ts.Seconds, ts.Milliseconds / 1000);
            Console.WriteLine(elapsedTime);
        }
    }
