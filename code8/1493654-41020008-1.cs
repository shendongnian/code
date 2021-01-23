    public static IEnumerable<TEntity> In<TEntity, TMember>(
        this IEnumerable<TEntity> source,
        Func<TEntity, TMember> projector, params TMember[] validCases)
    {
        var validSet = new HashSet<TMember>(validCases);
        return source.Where(s => validSet.Contains(projector(s)));
    }
