    public IList<T> Search<T>(string propertyName, string query, DbSet<T> set) 
    {
        var equalsQuery = set.Where(GetExpression<T>(propertyName, query, "Equals"));
        var containsQuery = set.Where(GetExpression<T>(propertyName, query, "Contains")).Take(10); // Don't want too many or else a search for "a" would yield too many results
    
        var result = equalsQuery.Union(containsQuery).ToList();
        return result;
    }
