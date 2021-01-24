    public static IQueryable<T> MyQuery<T>(this DbContext context)
                where T : class
            {
                return context.Set<T>().AsQueryable();
            }
