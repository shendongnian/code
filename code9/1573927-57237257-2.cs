    public static void Loop(sbyte fromInclusive, sbyte toInclusive,
        sbyte step, Action<sbyte> action)
    {
        var index = fromInclusive;
        while (true)
        {
            action(index);
            sbyte nextIndex = unchecked((sbyte)(index + step));
            if (step > 0)
            {
                if (nextIndex < index) break; // Overflow
                if (nextIndex > toInclusive) break;
            }
            else if (step < 0)
            {
                if (nextIndex > index) break; // Overflow
                if (nextIndex < toInclusive) break;
            }
            index = nextIndex;
        }
    }
    public static void Loop(sbyte fromInclusive, sbyte toInclusive,
        Action<sbyte> action) => Loop(fromInclusive, toInclusive, 1, action);
