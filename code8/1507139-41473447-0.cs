    public static class DataRecordExtension
    {
        public static SqlDataRecord WithInt64(this SqlDataRecord record, int ordinal, long value)
        {
            record.SetInt64(ordinal, value);
            return record;
        }
    }
