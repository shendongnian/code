    public static T GetValueOrNull<T>(this IDataReader reader, string column)
    {
         int ordinal;
         if(!string.IsNullOrEmpty(column) && !reader.IsDBNull(reader.GetOrdinal(column)))
              if(int.TryParse(reader.GetOrdinal(column).ToString(), out ordinal))
                   return (T)reader.GetValue(ordinal);
    
          return default(T);
    }
