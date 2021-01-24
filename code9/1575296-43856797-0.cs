    public static IQueryable<T> WhereEquals<T>(this IQueryable<T> source, Func<T, string> expression, string queryParam)
        {
            if (string.IsNullOrWhiteSpace(queryParam))
            {
                return source;
            }
            return source.Where(x => expression(x).Trim().ToLower() == queryParam.Trim().ToLower());
        }
