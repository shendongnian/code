    public class DataContext : DbContext, IDataContext {
        //...other code removed for brevity
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters) {
            return Database.SqlQuery<TElement>(sql,parameters);
        }
        public int ExecuteSqlCommand(string sql, params object[] parameters) {
            return Database.ExecuteSqlCommand(sql,parameters);
        }
    }
