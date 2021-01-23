    public static Page<TRet> PagedFetch<T1, T2, TRet>(this PetaPoco.IDatabase db, long page, long itemsPerPage, Func<T1, T2, TRet> cb, string sql, params object[] args)
            {
                SQLParts parts;
                if (!db.Provider.PagingUtility.SplitSQL(sql, out parts))
                    throw new Exception("Unable to parse SQL statement for paged query");
                
                db.Provider.BuildPageQuery((page - 1) * itemsPerPage, itemsPerPage, parts, ref args);
    
                sql = string.Format("{0} offset {1} rows fetch next {2} rows only", sql, (page - 1) * itemsPerPage, itemsPerPage);
    
                var data = db.Fetch(cb, sql, args);
    
                var result = new Page<TRet>
                {
                    Items = data,
                    TotalItems = db.ExecuteScalar<long>(parts.SqlCount),
                    CurrentPage = page,
                    ItemsPerPage = itemsPerPage
                };
    
                result.TotalPages = result.TotalItems / itemsPerPage;
    
                if ((result.TotalItems % itemsPerPage) != 0)
                    result.TotalPages++;
    
                return result;
            }
