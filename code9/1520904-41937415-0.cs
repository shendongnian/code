    public static void RemoveOrphans<TEntity>(this IDbSet<TEntity> entities,
        Expression<Func<TEntity, bool>> orphanPredicate)
        where TEntity: class
    {
        entities.Where(orphanPredicate).ToList().ForEach(e => entities.Remove(e));
    }
