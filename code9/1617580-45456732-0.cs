    public static class QueryableExtensions
    {
        public static IReadOnlyCollection<TResult> GetDistinctValuesForProperty<T, TResult>(this IQueryable<T> query, Expression<Func<T, TResult>> propertyAccess)
        {
            return query.Select(propertyAccess).Distinct().ToList();
        }
    
    }
    
    // Example
    var personQuery = DbContext.Set<Person>();
    var distinctNames = personQuery.GetDistinctValuesForProperty(x => x.Name);
