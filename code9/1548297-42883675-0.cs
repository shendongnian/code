    public IList<T> SearchByName<T>(string query, DbSet<T> set) 
          where T: IName
    {
        var equalsQuery = set.Where(f => f.Name.Equals(query));
        var containsQuery = set.Where(f => f.Name.Contains(query)).Take(10); // Don't want too many or else a search for "a" would yield too many results
    
        var result = equalsQuery.Union(containsQuery).ToList();
        ... // go on to return a view
    }
