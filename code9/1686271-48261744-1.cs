    public class DBHelper
    {
        private readonly string _connectionString,
                                _sqlToExecuteOnConnectionOpen;
            
        public DBHelper(string connectionString)
        {
            _connectionString = connectionString;
            _sqlToExecuteOnConnectionOpen = "Your sql goes here";
        }
        
        public void ExecuteSql(Action<SQliteConnection> action)
        {
            using(var con = new SQliteConnection(_connectionString))
            {
                using(var cmd = new SQliteCommand(_sqlToExecuteOnConnectionOpen, con)
                {
                    con.Open();
                    // of course, any parameters goes here...
                    cmd.ExecuteNonQuery(); 
                }
                action(con);
            }
        }
    }
