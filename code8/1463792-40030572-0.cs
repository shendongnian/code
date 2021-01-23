    public static class DataReaderExtensions
    {
    	public static DateTime? GetNullableDateTime(this IDataReader source, string name)
    	{
    		return source.GetNullableDateTime(source.GetOrdinal(name));
    	}
    	public static DateTime? GetNullableDateTime(this IDataReader source, int i)
    	{
    		return !source.IsDBNull(i) ? source.GetDateTime(i) : (DateTime?)null;
    	}
    }
