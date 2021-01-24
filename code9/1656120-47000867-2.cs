    public async Task<IEnumerable<T>> TypedQuery<T>(string myQuery)
    {
        try
        {
            using (var db = new DbContext(ConnString))
            {
                return await db.Database
                    .SqlQuery<T>(myQuery)
                    .ToListAsync()
                    .ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            // Log error here
            // Consider if the query can be retried
            // Consider whether the exception should be propogated or swallowed
            // Should the return type extended to indicate success / failure
            return Enumerable.Empty<T>();
        }
    }
