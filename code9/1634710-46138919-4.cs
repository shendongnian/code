    static void Main(string[] args)
    {
        long sum = 0;
        var stopwatch = new System.Diagnostics.Stopwatch();
        var numberOfTimes = 1000 * 1000;
        for (int i = 0; i < 100; i++)
        {
            stopwatch.Restart();
            for (int j = 0; j < numberOfTimes; j++)
            {
                var a = new int[] { j % 2, j % 3, j % 4, j % 5 };
                var r = RemoveDuplicates(a);
            }
            stopwatch.Stop();
            sum += stopwatch.ElapsedMilliseconds;
            // Console.WriteLine(string.Format("{0} => {1}", string.Join(",", a), string.Join(",", r)));
        }
        double avg = sum / 100;
        Console.WriteLine("Average execution time (100 executions) is {0}", avg);
        Console.ReadKey();
    }
