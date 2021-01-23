    public static class SqlDataReaderExtensions
    {
        public int GetInt32(this SqlDataReader reader, int ordinal, int defValue = default(int))
        {
            return (reader.IsDBNull(ordinal) ? defValue : reader.GetInt32(ordinal);
        }
        public string GetString(this SqlDataReader reader, int ordinal, int defValue = "")
        {
            return (reader.IsDBNull(ordinal) ? defValue : reader.GetString(ordinal);
        }
        public int GetDecimal(this SqlDataReader reader, int ordinal, decimal defValue = default(decimal))
        {
           ....
        }
    }
