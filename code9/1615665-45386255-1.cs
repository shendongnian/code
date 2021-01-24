    public class ConnectionStrings
    {
        public ConnectionStrings(string sql, string noSql)
        {
            Sql = sql;
            NoSql = noSql;
        }
    
        public string Sql { get; private set; }
        public string NoSql { get; private set; }
    }
    
