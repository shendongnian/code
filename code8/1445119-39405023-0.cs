    public class EFDbSetProvider<TEntity> : IQueryableProvider<TEntity>
    where TEntity : class
    {
        public TResult Execute<TResult>(Expression expression)
        {
            using (dbContext = new DbContext())
            {
                 return (TResult) dbContext.Set<TEntity>.Provider.Execute(expression);
            }
        }
    }
