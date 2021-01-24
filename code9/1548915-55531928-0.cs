    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    
    namespace MGame.Data.Helpers
    {
        public static class IncludeBuilder
        {
            public static IQueryable<TSource> Include<TSource>(this IQueryable<TSource> queryable, params string[] navigations) where TSource : class
            {
                if (navigations == null || navigations.Length == 0) return queryable;
    
                return navigations.Aggregate(queryable, EntityFrameworkQueryableExtensions.Include);  // EntityFrameworkQueryableExtensions.Include method requires the constraint where TSource : class
            }
        }
    }
