    public class Dummy
    {
        public bool? Soother { get; set; } = true;
    }
    public class Lab
    {
        Dummy _dummy = new Dummy();
        ulong _iterations = 5000000UL;
        const bool _propertyValue = true;
        const string _propertyName = "Soother";
        public BenchmarkReport RunNative()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (ulong i = 0; i < _iterations; i++)
            {
                _dummy.Soother = _propertyValue;
            }
            stopwatch.Stop();
            return new BenchmarkReport("Native", stopwatch.Elapsed, _iterations);
        }
        public BenchmarkReport RunLambdaExpression()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (ulong i = 0; i < _iterations; i++)
            {
                _dummy.Set(_propertyName, _propertyValue);
            }
            stopwatch.Stop();
            return new BenchmarkReport("Lambda Expression", stopwatch.Elapsed, _iterations);
        }
        public BenchmarkReport RunPropertyInfo()
        {
            PropertyInfo propertyInfo = typeof(Dummy).GetProperty(_propertyName);
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (ulong i = 0; i < _iterations; i++)
            {
                propertyInfo.SetValue(_dummy, _propertyValue);
            }
            stopwatch.Stop();
            return new BenchmarkReport("Property Info", stopwatch.Elapsed, _iterations);
        }
    }
    public class BenchmarkReport
    {
        public string Name { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public ulong Iterations { get; set; }
        public BenchmarkReport(string name, TimeSpan elapsedTime, ulong iterations)
        {
            Name = name;
            ElapsedTime = elapsedTime;
            Iterations = iterations;
        }
    }
