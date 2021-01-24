    public interface IDataContext {
        //...other members
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
        int ExecuteSqlCommand(string sql, params object[] parameters);
    }
