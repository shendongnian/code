    public static object GetString(this NpgslDataReader source, string colname)
    {
         if(string.IsNullOrEmpty(colname))
            throw ArgumentException("Need a column name");
         return source.GetString(source.GetOrdinal(colname));
    }
