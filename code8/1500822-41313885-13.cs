    public static IQueryable<TSource> Between<TSource, TKey, TLowHigh>(
          this IQueryable<TSource> source, 
          Expression<Func<TSource, TKey>> keySelector, 
          TLowHigh low, 
          TLowHigh high,
          bool inclusive = true) 
              where TKey : IComparable<TKey>
    {
        var key = Expression.Invoke(keySelector, keySelector.Parameters.ToArray());
        var intLow = int.Parse(low.ToString());
        var intHigh = int.Parse(high.ToString());
        var lowerBound = (inclusive)
                ? Expression.GreaterThanOrEqual(key, Expression.Constant(intLow, typeof(int)))
                : Expression.GreaterThan(key, Expression.Constant(intLow, typeof(int)));
        var upperBound = (inclusive)
                ? Expression.LessThanOrEqual(key, Expression.Constant(intHigh, typeof(int)))
                : Expression.LessThan(key, Expression.Constant(intHigh, typeof(int)));
        var and = Expression.AndAlso(lowerBound, upperBound);
        var lambda = Expression.Lambda<Func<TSource, bool>>(
                        and, keySelector.Parameters);
        return source.Where(lambda);
    }
