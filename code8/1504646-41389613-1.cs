        public SqlServerContext() : base("name=SqlServerContext")
        {
        }
    }
    
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    class MySqlContext : ApplicationContext
    {
        public MySqlContext() : base("name=MySqlDAOContext")
        {
        }
    }
