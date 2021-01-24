    class so42112722
    {
        private readonly int[] input = Enumerable.Range(1, 5000).ToArray();
        public so42112722()
        {
        }
        public void RunTest()
        {
            var t1 = timeAction(ParallelUsingLoopStateAndDictionary);
            var t2 = timeAction(ParallelUsingPLinq);
            var diff = (t1 - t2);
            var pct = diff / (t1 > t2 ? t2 : t1);
            Console.WriteLine("| {0:0,000.000} | {1:0,000.000} | {2} is {3:0.00%} faster!", t1, t2, (diff > 0 ? "PLinq" : "ConcurrentDictionary"), Math.Abs(pct));
        }
        double timeAction(Action action)
        {
            var name = action.Method.Name;
            var tStart = DateTime.Now;
            action();
            var tEnd = DateTime.Now;
            var duration = (tEnd - tStart).TotalMilliseconds;
            return duration;
        }
        private void ParallelUsingLoopStateAndDictionary()
        {
            var resultDictionary = new ConcurrentDictionary<double, Dictionary<DateTime, double>>();
            Parallel.ForEach(input, (item, state, index) =>
            {
                resultDictionary.TryAdd(index, ExpensiveTransformation(item));
            });
            var resultList = resultDictionary.Keys.OrderBy(k => k).Select(k => resultDictionary[k]).ToList();
        }
        private void ParallelUsingPLinq()
        {
            var reultslist = input
                .AsParallel()
                .AsOrdered()
                .Select(item => ExpensiveTransformation(item))
                .ToList();
        }
        private Dictionary<DateTime, double> ExpensiveTransformation(double item)
        {
            Random rnd = new Random();
            int iterCount = 5000;
            var dict = new Dictionary<DateTime, double>();
            for (int i = 0; i < iterCount; i++)
            {
                DateTime dt = DateTime.Now.AddDays(-i * 3).AddMinutes(i).AddSeconds(item * rnd.Next(100, 1000)).AddMilliseconds(-i);
                var val = Math.Pow(item, rnd.Next(2, 5)) + rnd.Next(100, iterCount) / (i + 1);
                dict.Add(dt, val);
            }
            return dict;
        }
    }
