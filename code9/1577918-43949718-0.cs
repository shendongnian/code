     public Func<Q, object> GetSortProperty<Q>(IQueryable<Q> data, string SortColumn)
        {
            if (!string.IsNullOrWhiteSpace(SortColumn))
            {
                Func<Q, object> sort = i => i.GetType().GetProperty(SortColumn).GetValue(i, null);
                return sort;
            }
            return null;
        }
