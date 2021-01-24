    public class HomeDataAccessConfig
    {
        public readonly string UserName;
        public HomeDataAccessConfig (string userNamr) {
            if (string.IsNullOrWhiteSpace(userName)) throw new ...
            this.Usrrname = userName.
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
