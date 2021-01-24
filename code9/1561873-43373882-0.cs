    public static class LinqExtensions
    {
        public static IEnumerable<T> Yield<T>(this IEnumerable<T> models, int numberResults) => models.AsQueryable().YieldQueryable(numberResults);
        public static IQueryable<T> Yield<T>(this IQueryable<T> models, int numberResults) => models.YieldQueryable(numberResults);
        /// <summary>
        /// Lists database entities by a number of results or lists them all 
        /// </summary>
        /// <typeparam name="T">The generic entity to list</typeparam>
        /// <param name="models">The query to yield</param>
        /// <param name="numberResults">The number of results to yield</param>
        /// <returns></returns>
        private static IQueryable<T> YieldQueryable<T>(this IQueryable<T> models, int numberResults) => numberResults > 0 ? models.Take(numberResults) : models;
    }
