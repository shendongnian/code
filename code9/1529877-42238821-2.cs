    public static ulong Add(this ulong baseValue, long offset)
    {
        decimal adjustedValue = (decimal)baseValue + offset;
        if (adjustedValue > ulong.MaxValue) throw new ArgumentOutOfRangeException("Too big to fit!");
        if (adjustedValue < ulong.MinValue) throw new ArgumentOutOfRangeException("Too small to fit!");
        return (ulong)adjustedValue;
    }
