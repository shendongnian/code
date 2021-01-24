    public static class AutoFixtureExtensions
    {
        public static TSeed FreezeSeed<TSeed>(this IFixture fixture, TSeed seed)
        {
            fixture.Inject<TSeed>(seed);
            return seed;
        }
    }
