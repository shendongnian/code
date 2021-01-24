    public class foo
	{
		public string FooName
		{
			get;
			set;
		}
		public override string ToString()
		{
			return FooName;
		}
	}
	public class Bar
	{
		public string BarName
		{
			get;
			set;
		}
		public override string ToString()
		{
			return BarName;
		}
	}
	public IList<T> Search<T>(string query, DbSet<T> set)
	{
		var equalsQuery = set.AsEnumerable().Where(f => f.ToString().Equals(query));
		var containsQuery = set.AsEnumerable().Where(f => f.ToString().Contains(query)).Take(10); 
		var result = equalsQuery.Union(containsQuery).ToList(); . . . // go on to return a view
	}
