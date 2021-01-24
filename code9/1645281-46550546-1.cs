<!-- -->
    // PCL
    public interface ISomeRepository
    {
        void DoSomething();
    }
    public interface ISomeService
    {
        void DoThings();
    }
    public class SomeService : ISomeService
    {
        private ISomeRepository _someRepository;
        SomeService(ISomeRepository someRepository)
        {
            _someRepository = someRepository;
        }
        public void DoThings()
        {
            // do things via DAL
        }
    }
    public class SomeProxyService : ISomeService
    {
        private HttpClient _httpClient;
        SomeProxyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public void DoThings()
        {
            // do things via HTTP
        }
    }
