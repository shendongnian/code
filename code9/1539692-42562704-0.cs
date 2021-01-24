    public class HomeDataAccessConfig
    {
        public readonly string Value;
        public HomeDataAccessConfig (string value) {
            if (string.IsNullOrWhiteSpace(value)) throw new ...
            this.Value = value;
        }
    }
    public class HomeDataAccess
    {
        private readonly HomeDataAccessConfig config;
        private readonly IQueryManager manager;
        public HomeDataAccess(HomeDataAccessConfig config, IQueryManager manager) {
            this.config = config;
            this.manager = manager;
        }
    }
