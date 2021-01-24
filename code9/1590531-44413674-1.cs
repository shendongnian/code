    public class Consumer
    {
        private RSDatabaseConnectionCreator _connectionCreator;
        // Constructor injection
        public Consumer (RSDatabaseConnectionCreator connectionCreator)
        {
            _connectionCreator = connectionCreator;
        }
        public void QueryExecution(string SQLQuery)
        {
            using (var conn = _connectionCreator.CreateConnection(dbName, true, true)) {
                if (conn != null) {
                    ...
                }
            }
        }
    }
