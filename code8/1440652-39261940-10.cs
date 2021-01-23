    public static string EncodeTransmissionTimestamp(DateTime date)
    {
    	long shortTicks = (date.Ticks - 631139040000000000L) / 10000L; 
    	return Convert.ToBase64String(BitConverter.GetBytes(shortTicks)).Substring(0, 7);
    }
    
    public static DateTime DecodeTransmissionTimestamp(string encodedTimestamp)
    {
    	byte[] data = new byte[8];
    	Convert.FromBase64String(encodedTimestamp + "AAAA=").CopyTo(data, 0);
    	return new DateTime((BitConverter.ToInt64(data, 0) * 10000L) + 631139040000000000L);
    }
