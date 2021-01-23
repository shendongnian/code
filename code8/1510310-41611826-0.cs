    private static bool TryCalculateRange(int totalCount, int pageLength, int page, out int skip, out int take)
    {
        skip = 0;
        take = 0;
        if(pageLength <= 0)
            return false;
        skip = pageLength * (page - 1);
        if(skip >= totalCount)
            skip = 0;
        take = totalCount - skip;
        if(take > pageLength)
            take = pageLength;
        return true;
    }
    public static IQueryable<T> Pag<T>(IOrderedQueryable<T> data, int totalRows, int reqLength, int pageNum)
    {
        int skip;
        int take;
        return TryCalculateRange(totalRows, reqLength, pageNum, out skip, out take))
               ? data.Skip(skip).Take(take)
               : data;
    }
    public static IEnumerable<T> Pag<T>(IOrderedEnumerable<T> data, int totalRows, int reqLength, int pageNum)
    {
        int skip;
        int take;
        return TryCalculateRange(totalRows, reqLength, pageNum, out skip, out take))
               ? data.Skip(skip).Take(take)
               : data;
        }
    }
