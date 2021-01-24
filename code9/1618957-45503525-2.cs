    public static IEnumerable<DataRow> SortByNonEmpty(
          this IEnumerable<DataRow> source, string columnName)
    {
        var query = from r in source
                    let value = r.Field<string>(columnName)
                    where !String.IsNullOrEmpty(value)
                    orderby value
                    select r;
        using (var ordinalEnumerator = source.GetEnumerator())
        using (var sortedEnumerator = query.GetEnumerator())
        {
            while (ordinalEnumerator.MoveNext())
            {
               if (String.IsNullOrEmpty((ordinalEnumerator.Current.Field<string>(columnName))))
                   yield return ordinalEnumerator.Current;
               sortedEnumerator.MoveNext();
               yield return sortedEnumerator.Current;
            }
        }
    }
