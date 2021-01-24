    public static class BlogIncludes
    {
        public const string Posts = "Posts";
        public const string Author = "Posts.Author";
    }
    internal static class DataAccessExtensions
    {
        internal static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, 
            params string[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
    }
    public Blog GetById(int ID, params string[] includes)
    {
        var blog = context.Blogs
            .Where(x => x.BlogId == id)
            .IncludeMultiple(includes)
            .FirstOrDefault();
        return blog;
    }
