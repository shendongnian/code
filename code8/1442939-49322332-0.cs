      public static async Task<List<T>> ToListAsync<T>(this IDocumentQuery<T> queryable)
            {
                var list = new List<T>();
                while (queryable.HasMoreResults)
                {   //Note that ExecuteNextAsync can return many records in each call
                    var response = await queryable.ExecuteNextAsync<T>();
                    list.AddRange(response);
                }
                return list;
            }
            public static async Task<List<T>> ToListAsync<T>(this IQueryable<T> query)
            {
                return await query.AsDocumentQuery().ToListAsync();
            }
