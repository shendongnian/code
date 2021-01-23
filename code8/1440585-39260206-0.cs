    public static class SqlDataReaderExtensions
    {
        public int GetInt32(this SqlDataReader reader, int ordinal, int defValue = default(int))
        {
            return (reader.IsDBNull(ordinal) ? defValue : reader.GetInt32(ordinal);
        }
    
        public int GetDecimal(this SqlDataReader reader, int ordinal, int defValue = default(decimal))
        {
           ....
        }
    }
