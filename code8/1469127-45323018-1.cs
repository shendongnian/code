    namespace MyProject.Orm
    {
        public static class DatabaseConnection
        {
            public static string ConnectionString { get; set; }
    
            public static SqlConnection ConnectionFactory()
            {
                return new SqlConnection(ConnectionString);
            }
        }
    }
