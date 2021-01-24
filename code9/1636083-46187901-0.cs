    class YourClass{
        private string _connectionString;
        YourClass(IOptions<ConnectionConfig> connectionConfig){
           var connection = connectionConfig.Value;
           _connectionString = connection.Analysis;
        }
        
        //Your implementation
        public List<DapperTest> ReadAll()
        {
            var data = new List<DapperTest>();
            using (IDbConnection db = new SqlConnection(_connectionString)
            {
                data = db.Query<DapperTest>("select * from testTable").ToList();
            }
           return data;
       }
    }
