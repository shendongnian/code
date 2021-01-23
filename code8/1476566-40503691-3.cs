    [LegacyJitX86Job, LegacyJitX64Job, RyuJitX64Job]
    public class MathRoundBenchmarks
    {
        private const int N = 100;
        private double[] data;
        [Setup]
        public void Setup()
        {
            var rand = new Random(0);
            data = new double[N];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = rand.NextDouble() * int.MaxValue * 2 +
                          int.MinValue + rand.NextDouble();
            }
        }
        [Benchmark(OperationsPerInvoke = N)]
        public int MathRound()
        {
            int d = 0;
            for (int i = 0; i < data.Length; ++i)
                d ^= (int) Math.Round(data[i]);
            return d;
        }
    }
