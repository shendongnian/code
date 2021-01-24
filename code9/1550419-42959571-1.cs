    public interface IConfiguration
    {
        public IDictionary<int, int> Data { get; }
    }
    public class YourClass
    {
        private readonly IConfiguration _configuration;
        public YourClass(IConfiguration configuration)
        {
            _configuration = configuration
        }
        public bool GetValue(int id)
        {
            return _configuration.Data[id];
        }
    }
    public class CachedConfiguartion : IConfiguartion
    {
        public IDictionary<int, int> _cachedData;
        public IDictionary<int, int> Data { get { return _cachedCData; } }
        public CachedConfiguartion() {}
    }
