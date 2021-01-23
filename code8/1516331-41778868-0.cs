    public string GetString(SqlDataReader reader, int columnIndex)
    {
       if(!reader.IsDBNull(columnIndex))
           return reader.GetString(columnIndex);
       return string.Empty;
    }
