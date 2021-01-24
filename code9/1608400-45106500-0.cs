    if (typeof(ISoftDelete).GetTypeInfo().IsAssignableFrom(typeof(TEntity)))
    {
        if (UnitOfWorkManager?.Current == null || UnitOfWorkManager.Current.IsFilterEnabled(AbpDataFilters.SoftDelete))
        {
            query = query.Where(e => !((ISoftDelete)e).IsDeleted);
        }
    }
