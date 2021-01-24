        /// <summary>
        /// Query with dynamic Include
        /// </summary>
        /// <typeparam name="T">Entity</typeparam>
        /// <param name="context">dbContext</param>
        /// <param name="includeProperties">includeProperties with ; delimiters</param>
        /// <returns>Constructed query with include properties</returns>
        public static IQueryable<T> MyQueryWithDynamicInclude<T>(this DbContext context, string includeProperties)
           where T : class
        {            
            string[] includes = includeProperties.Split(';');
            var query = context.Set<T>().AsQueryable();
            foreach (string include in includes)
                query = query.Include(include);
            return query;
        }
