    public static SqlDataRecord CreateDataRecord(long value)
    {
        var record = new SqlDataRecord(new SqlMetaData("n", SqlDbType.BigInt));
        record.SetInt64(0, value);
        return record;
    }
