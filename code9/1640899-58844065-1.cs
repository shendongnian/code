     /// <summary>
     ///     Specifies related entities to include in the query result.
     /// </summary>
     /// <typeparam name="T">The type of entity being queried.</typeparam>
     /// <param name="source">The source <see cref="IQueryable{T}" /> on which to call Include.</param>
     /// <param name="paths">The lambda expressions representing the paths to include.</param>
     /// <returns>A new <see cref="IQueryable{T}" /> with the defined query path.</returns>
     internal static IQueryable<T> Include<T>(this IQueryable<T> source, params Expression<Func<T, object>>[] paths)
     {
         if (paths != null)
             source = paths.Aggregate(source, (current, include) => current.Include(include.AsPath()));
    
         return source;
     }
