    public class CachingOrderRepository : IOrderRepository
    {
        private readonly IOrderRepository repository;
        private readonly ICache cache;
        private readonly ITimeProvider time;
        
        public CachingOrderRepository(
            IOrderRepository repository, ICache cache, ITimeProvider time)
        {
            this.repository = repository;
            this.cache = cache;
            this.time = time;
        }
        public IEnumerable<Order> GetAllValid() =>
            this.cache.GetOrAdd(
                key: "AllValidOrders",
                cacheDuration: this.TillMidnight,
                valueFactory: () => this.repository.GetAllValid().ToList().AsReadOnly());
                
        private TimeSpan TillMidnight => this.Tomorrow - this.time.Now;
        private DateTime Tomorrow => this.time.Now.Date.AddHours(24);
    }
