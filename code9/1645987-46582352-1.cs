    public static async Task<List<T>> ToListReadUncommittedAsync<T>(this IQueryable<T> query, DbContext context)
    {
        using (var transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadUncommitted))           {
        {
            var result = await query.ToListAsync();
            transaction.Commit();
            return result;
        }
    }
 
