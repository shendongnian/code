    public static class StaticRandom
    {
        static int seed = Environment.TickCount;
        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));
        public static int Rand()
        {
            return random.Value.Next();
        }
    }
