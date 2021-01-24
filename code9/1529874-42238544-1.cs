    static void Main(string[] args)
    {
        ulong[] values = { ulong.MinValue, ulong.MaxValue, long.MaxValue };
        long[] adjust = { 0, 1, -1, long.MinValue, long.MaxValue };
        for (int i = 0; i < values.Length; i++)
        {
            for (int j = 0; j < adjust.Length; j++)
            {
                ulong value = values[i];
                bool result = AdjustValue(adjust[j], ref value);
                Console.WriteLine($"{values[i]} + {adjust[j]} = {values} (overflow: {!result})");
            }
        }
    }
    static bool AdjustValue(long amount, ref ulong value)
    {
        ulong adjustValue = value + (ulong)amount;
        if (amount < 0 && adjustValue > value)
            return false;
        if (amount > 0 && adjustValue < value)
            return false;
        value = adjustValue;
        return true;
    }
