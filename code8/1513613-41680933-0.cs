    public static class Extensions
    {
      public static IDataReader Read(this IDataReader reader, Action<IDataReader> action)
      {
        if(reader.HasRows)
        {
          while(reader.Read())
          {
            action(reader);
          }
        }
      }
    }
