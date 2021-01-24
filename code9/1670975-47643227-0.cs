    public class Filter
    {
    	public List<FilterEntry> Inclusions { get; set; }
    	public List<FilterEntry> Exclusions { get; set; }
    	public IQueryable<User> ApplyTo<User>(IQueryable<User> queryable)
    	{
    		// TODO: Dynamically build this string instead of hard-coding it.
    		//       You would probably iterate through Inclusions and Exclusions
    		//       appending to the where clause as you go.
    		var whereClause = "Age == @0 && Name != @1 && Name != @2";
    		var params = new object[] { 33, "John", "Peter" };
    		return queryable.Where(whereClause, params);
    	}
    }
