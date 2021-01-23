    public static long MapUlongToLong(ulong ulongValue)
    {
        return unchecked((long)ulongValue + long.MinValue);
    }
    public static ulong MapLongToUlong(long longValue)
    {
        return unchecked((ulong)(longValue - long.MinValue));
    }
