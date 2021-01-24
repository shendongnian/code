    public class TasksWithoutPasswordContext : DbContext
    {
        public TasksWithoutPasswordContext()
            : base(GetDbConnection(), false)
        {
        }
        static DbConnection GetDbConnection()
        {
            var conn = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateConnection();
            conn.ConnectionString = "<connectionstring>";
            return conn;
        }
    }
