    public static IQueryable<TDestination> ProjectTo<TDestination>(
        this IQueryable source,
        IConfigurationProvider configuration,
        IDictionary<string, object> parameters,
        params string[] membersToExpand
    );
