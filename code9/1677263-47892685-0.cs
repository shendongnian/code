    public static partial class DbSetExtensions
    {
    	public static T FindFirst<T>(this DbSet<T> source, Expression<Func<T, bool>> predicate)
    		where T : class
    	{
    		return source.Local.AsQueryable().FirstOrDefault(predicate) ?? source.FirstOrDefault(predicate);
    	}
    }
