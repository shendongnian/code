    public class CurrentMethodInfoBenchmarks
    {
        [Benchmark]
        public string MethodNameReflection() => MethodBase.GetCurrentMethod().Name;
        [Benchmark]
        public string MethodNameNameOf() => nameof(MethodNameNameOf);
        [Benchmark]
        public string TypeName() => GetType().Name;
        [Benchmark]
        public string TypeNameReflection() => MethodBase.GetCurrentMethod().DeclaringType.Name;
    }
