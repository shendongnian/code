        public static readonly string ConnectionString connString = ConfigurationManager.ConnectionStrings["YOURCONNECTION"].ConnectionString.ToString();
        
        private void TestMethod()
        {
            using (var dbConn = new SqlConnection(connString)) {
                string query = "select ....";
                using (var dbCommand = new SqlCommand(query, dbConn)) {
                    ...
                }
            }
        }
