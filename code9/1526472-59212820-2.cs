    public static class Extensions
    {
        public static IQueryable<IGrouping<TSource, TSource>> GroupByExcept<TSource, TXKey>(this IQueryable<TSource> source, Expression<Func<TSource, TXKey>> exceptKeySelector) =>
            GroupByExcept(source, exceptKeySelector, s => s);
        
        public static IQueryable<IGrouping<TSource, TElement>> GroupByExcept<TSource, TXKey, TElement>(this IQueryable<TSource> source, Expression<Func<TSource, TXKey>> exceptKeySelector, Expression<Func<TSource, TElement>> elementSelector)
        {
            return source.GroupBy(BuildKeySelector(), elementSelector);
            
            Expression<Func<TSource, TSource>> BuildKeySelector()
            {
                var exclude = typeof(TXKey).GetProperties()
                    .Select(p => (p.PropertyType, p.Name))
                    .ToHashSet();
                var itemExpr = Expression.Parameter(typeof(TSource));
                var keyExpr = Expression.MemberInit(
                    Expression.New(typeof(TSource).GetConstructor(Type.EmptyTypes)),
                    from p in typeof(TSource).GetProperties()
                    where !exclude.Contains((p.PropertyType, p.Name))
                    select Expression.Bind(p, Expression.Property(itemExpr, p))
                );
                return Expression.Lambda<Func<TSource, TSource>>(keyExpr, itemExpr);
            }
        }
    }
