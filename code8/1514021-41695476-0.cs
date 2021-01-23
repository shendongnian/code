    namespace ClassLibrary1 {
        using Dapper;
    
        public class Class1 {
            private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
        
            public Class1() {}
            public List<dynamic> GetRecords() {
                string query = "select * from contacts";
                using (var db = new SqlConnection(connectionString))
                    return db.Query<dynamic>(query).AsList();
            }
        }
    }
