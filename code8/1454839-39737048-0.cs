    public class OtherDbService
    {
        private readonly string _connectionString;
        public OtherDbService(IOptions<OtherDbOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }
        public object GetData()
        {
            // create your database connection and return data
        }
    }
