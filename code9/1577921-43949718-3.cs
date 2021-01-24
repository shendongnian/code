     public Func<Q, string> GetSortProperty<Q>(IQueryable<Q> data, string SortColumn)
        {
            if (!string.IsNullOrWhiteSpace(SortColumn))
            {
                Func<Q, string> sort = i => (string)i.GetType().GetProperty(SortColumn).GetValue(i, null);
                return sort;
            }
            return null;
        }
