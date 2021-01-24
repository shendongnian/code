    private static void SeedLanguages(FilterListsDbContext context)
    {
        Seed<Language>(context, c => c.Languages);
    }
    private static void Seed<T>(FilterListsDbContext context, Func<FilterListsDbContext, DbSet<T>> setFunc) where T : class
    {
        var set = setFunc(context);
        if (set.Any()) return;
    }
