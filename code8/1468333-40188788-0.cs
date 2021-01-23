    namespace NHibernate.Linq
    {
    	public static class LinqExtensionMethods
    	{
    		public static IQueryable<T> Query<T>(this ISession session)
    		{
                ...
