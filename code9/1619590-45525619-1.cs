    public static object GetString(this NpgsqlDataReader source, string colname)
    {
         if(string.IsNullOrEmpty(colname))
            throw ArgumentException("Need a column name");
         return source.GetString(source.GetOrdinal(colname));
    }
