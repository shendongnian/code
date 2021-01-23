    public interface IGenericDataRepository<T> where T : class
    {
    
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
     
    }
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        public virtual IList<T> GetList(Func<T, bool> where,
          params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var dbQuery = new session.Query<T>())
            {
                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Fetch<T, object>(navigationProperty);
                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            return list;
        }
    }
