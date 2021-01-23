    public static class PagingExtensions
    {
        public static IQueryable<Page<T>> ToPages<T>(this IQueryable<T> allRecords, int pageSize)
        {
            return allRecords.Select( (record, i) => new
            {
                PageNr = i / pageSize,
                Record = record,
            })
            .GroupBy(item => item.PageNr)
            // intermediate result: sequence of IGrouping<int, T>
            // where key is pageNr
            // and each element in the group are the records for this page
            .Select(group => new Page<T>
            {
                PageNr = group.Key,
                PageSize = pageSize,
                Contents = (IEnumerable<T>) group
            });
        }
    }
