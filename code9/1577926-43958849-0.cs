    public static class DataReaderExtenstions
    {
    	public static string GetNString(this DbDataReader reader, int ordinal)
    	{
    		return !reader.IsDBNull(ordinal) ? reader.GetString(ordinal) : null;
    	}
    	public static int? ReadNInt32(this DbDataReader reader, int ordinal)
    	{
    		return !reader.IsDBNull(ordinal) ? reader.GetInt32(ordinal) : (int?)null;
    	}
    	// Similar for Int16, Byte, Decimal, Double, DateTime etc.
    }
