    public static IQueryable<TDestination> ProjectTo<TDestination>(
        this IQueryable source,
        IConfigurationProvider configuration,
        object parameters,
        params Expression<Func<TDestination, object>>[] membersToExpand
    );
