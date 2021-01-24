    public static ulong Add(this ulong baseValue, long offset)
    {
        decimal adjustedValue = (decimal)baseValue + offset;
        return (ulong)adjustedValue;
    }
