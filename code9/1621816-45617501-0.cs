    public static int? GetInt32OrNull(this SqlDataReader reader, int index)
    {
        SqlInt32 value = reader.GetSqlInt32(index);
        if (value.IsNull)
        {
            return null;
        }
        return value.Value;
    }
