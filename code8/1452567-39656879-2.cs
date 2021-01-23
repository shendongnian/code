    public static Expression<Func<IQueryable<Something>, Object>> IncludeCommonFields()
    {
        // since the method returns an Expression, this will actually
        // get compiled to an expression tree
        return input => input.Fields.Include(z => z.Title, 
                                             z => z.InternalName, 
                                             z => z.TypeDisplayName);
    }
