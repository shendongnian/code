    private List<TEntity> GetEntities<TEntity>(Expression<Func<TEntity, bool>> 
    predicate = null) where TEntity : class
    {
        using (var context = new ExpensesEntities())
        {
            IQueryable<TEntity> data = context.Set<TEntity>();
            if (predicate != null)
            {
                data = data.Where(predicate);
            }
            return data.ToList();
         }
     }
