    class SqlServerContext : ApplicationContext
    {
        public SqlServerContext() : base("SqlServerContext")
        {
        }
    }
    
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    class MySqlContext : ApplicationContext
    {
        public MySqlContext() : base("MySqlDAOContext")
        {
        }
    }
