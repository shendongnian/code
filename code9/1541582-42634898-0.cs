    public interface IExecuteSql {
        int ExecuteSqlCommand(string sql, params object[] parameters);
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
    }
    public interface IUnitOfWork : IExecuteSql, //...other interfaces
    {
        //...other code removed for brevity
    }
