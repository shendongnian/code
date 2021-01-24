    public class OrdersController
    {
        public OrdersController([KeyFilter(CacheType.Order)]ICacheProvider cacheProvider)
        { }
    }
