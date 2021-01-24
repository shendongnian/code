    public class EntityFrameworkUnitOfWork : IUnitOfWork {
        //...other code removed for brevity
        public int ExecuteSqlCommand(string sql, params object[] parameters) {
            return context.Database.ExecuteSqlCommand(sql, parameters);
        }
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters) {
            return context.Database.SqlQuery<TElement>(sql, parameters);
        }
    }
