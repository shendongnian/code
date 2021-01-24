    public static void RemoveOrphans<TEntity>(this IDbSet<TEntity> entities,
        Func<TEntity, bool> orphanPredicate)
        where TEntity: class
    {
        entities.Local.Where(orphanPredicate).ToList().ForEach(e => entities.Remove(e));
    }
