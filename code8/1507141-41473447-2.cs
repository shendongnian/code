    public class DataRecordHelper
    {
        public static SqlDataRecord CreateDataRecordInt64(int ordinal, long value, params SqlMetaData[] metaData)
        {
            var record = new SqlDataRecord(metaData);
            record.SetInt64(ordinal, value);
            return record;
        }
    }
