    public static Expression<Func<TEntity, bool>> CreateSearchQuery<TEntity>(List<PropertyInfo> properties, string text, SearchType searchType = SearchType.Contains)
    {
        if (string.IsNullOrWhiteSpace(text) || properties == null || properties.Count == 0)
        {
            return null;
        }
        // For comparison
        //Expression<Func<ProductContainer, bool>> exp = q => searchText.Any(x => q.Product.ProductTitle.ToLower().Contains(x));
        var expressions = new List<Expression>();
        var entity = Expression.Parameter(typeof(TEntity), "q");
        //search type
        var searchMethod = typeof(string).GetMethod(searchType.ToString(), new[] { typeof(string) });
        //search terms
        var searchTerms = Expression.Constant(text.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        //search param
        var str = Expression.Parameter(typeof(string), "s");
        foreach (var property in properties.Where(
            x => x.GetCustomAttribute<NotMappedAttribute>() == null))
        {
            var entityProperty = Expression.Property(entity, property);
            var toLower = Expression.Call(entityProperty, "ToLower", Type.EmptyTypes);
            var contains = Expression.Call(toLower, searchMethod, str);
            var anyExpression = Expression.Lambda<Func<string, bool>>(contains, str);
            var any = Expression.Call(typeof(Enumerable), "Any", new[] { typeof(string) }, searchTerms, anyExpression);
            expressions.Add(any);
        }
        var ors = expressions.Aggregate((x, y) => Expression.Or(x, y));
        var exp = Expression.Lambda<Func<TEntity, bool>>(ors, entity);
        return exp;
    }
