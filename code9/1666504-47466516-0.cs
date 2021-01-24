    class CalculationFactory : IDisposable
    {
        private readonly Dictionary<int, CalculationBuilder> cache = new Dictionary<int, CalculationBuilder>();
        private readonly IUnityContainer container;
        public ICalculationBuilder Get(int year)
        {
            if (!cache.ContainsKey(year))
            {
                cache[year] = container.Resolve(typeof(ICalculationBuilder), new DependencyOverride<int>(year));
            }
            return cache[year];
        }
        public void Dispose()
        {
            cache.Clear();
        }
    }
