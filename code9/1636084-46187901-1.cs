    class YourClass{
        private string _connectionString;
    
        YourClass(string connectionString){
           _connectionString = connectionString;
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
