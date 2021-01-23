    [TestMethod]
    public void Test()
    {
        var items = Enumerable.Range(0, 10);
        int sleepMs;
        for (int i = 0; i <= 4; i++)
        {
            sleepMs = i * 25;
            var elapsed1 = CalcDurationOfCalculation(() => items.AsParallel().Select(SomeClause).ToArray());
            var elapsed2 = CalcDurationOfCalculation(() => items.Select(SomeClause).AsParallel().ToArray());
            Trace.WriteLine($"{sleepMs}: T1={elapsed1} T2={elapsed2}");
        }
        long CalcDurationOfCalculation(Action calculation)
        {
            var watch = new Stopwatch();
            watch.Start();
            calculation();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        
        int SomeClause(int value)
        {
            Thread.Sleep(sleepMs);
            return value * 2;
        }
    }
