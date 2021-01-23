    public static Expression<Func<IQueryable<Something>, Object>> IncludeCommonFields()
    {
        return input => input.Fields.Include(z => z.Title, 
                                             z => z.InternalName, 
                                             z => z.TypeDisplayName);
    }
