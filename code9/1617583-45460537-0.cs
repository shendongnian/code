    using System.Linq.Dynamic;
    public static async Task<IEnumerable<Object>> GetDistinctValuesForProperty<T>(this IQueryable<T> query, String PropertyName)
      {
      return await query.Select(PropertyName).Distinct().ToListAsync();
      }
