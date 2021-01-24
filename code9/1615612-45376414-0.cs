    public IEnumerable<TEntity> GetEntities<TEntity>(
        Expression<Func<TEntity, bool>> predicate = null)
    {
        using (var context = new ExpensesEntities())
        {
            var data = context.Set<TEntity>();
            if(predicate != null)
            {
                data = data.Where(predicate);
            }
            return data.ToList();
        }
    }
